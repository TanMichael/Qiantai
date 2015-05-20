using QTsys.Common.Constants;
using QTsys.DataObjects;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;


namespace QTsys.Common
{
    static class Utils
    {
        private const string CONN_CONFIG_PATH = @"..\..\mysql_set.xml";
        private static LogonToken _logonToken = new LogonToken { Status = false, UserName = "", Role = "" ,PWD=""};

        public static string GetMD5String(string source)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(source);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static ConnectionConfig ReadConnConfig()
        {
            ConnectionConfig config = new ConnectionConfig();

            XmlDocument doc = new XmlDocument();
            doc.Load(CONN_CONFIG_PATH);

            XmlNode root = doc.SelectSingleNode("mysqlset");//指定一个节点
            config.Server = root.Attributes["Server"].Value;
            config.Database = root.Attributes["Database"].Value;
            config.DataSource = root.Attributes["DataSource"].Value;
            config.UserId = root.Attributes["UserId"].Value;
            config.Password = root.Attributes["Password"].Value;
            config.Pooling = root.Attributes["pooling"].Value;
            config.CharSet = root.Attributes["CharSet"].Value;
            config.Port = root.Attributes["port"].Value;

            return config;
        }

        public static void UpdateConfig(ConnectionConfig config)
        {
            XmlDocument doc = new XmlDocument();//创建dom对象
            XmlElement root = doc.CreateElement("mysqlset");//创建根节点album

            root.SetAttribute("Server", config.Server);//
            root.SetAttribute("Database", config.Database);//
            root.SetAttribute("DataSource", config.DataSource);//
            root.SetAttribute("UserId", config.UserId);//
            root.SetAttribute("Password", config.Password);//
            root.SetAttribute("pooling", config.Pooling);//
            root.SetAttribute("CharSet", config.CharSet);//
            root.SetAttribute("port", config.Port);//
            doc.AppendChild(root);

            doc.Save(CONN_CONFIG_PATH);
        }

        public static LogonToken GetLogonToken()
        {
            return _logonToken;
        }

        public static void SetLogonToken(string userName, string role, string pwds,bool status = true)
        {
            _logonToken.UserName = userName;
            _logonToken.Role = role;
            _logonToken.Status = status;
            _logonToken.PWD = pwds;
            _logonToken.LogonTime = _logonToken.LastOperationTime = DateTime.Now;
        }

        public static void ClearLogonToken()
        {
            _logonToken = new LogonToken { Status = false, UserName = "", Role = "" };
        }

        public static string GetCurrentUsername()
        {
            if (_logonToken.Status != false)
            {
                return _logonToken.UserName;
            }
            else
            {
                // TODO log out
                return "";
            }
        }

        public static string GetCurrentPWD()
        {
            if (_logonToken.Status != false)
            {
                return _logonToken.PWD;
            }
            else
            {
                // TODO log out
                return "";
            }
        }

        public static Rights MapRightsToRole(string role)
        {
            Rights rights = 0;
            switch (role)
            { 
                case UserRoles.SYS_ADMIN:
                    rights = Rights.EMPLOYEE | Rights.CUSTOMER;
                    break;
                case UserRoles.SALES:
                    rights = Rights.SALES | Rights.CUSTOMER;
                    break;
                case UserRoles.ENGINEER:
                    rights = Rights.PRODUCT | Rights.MANUFACTURE;
                    break;
                case UserRoles.STORAGE:
                    rights = Rights.STORAGE;
                    break;
                case UserRoles.FINANCE:
                    rights = Rights.PRODUCT | Rights.FIN;    // TODO 对账单
                    break;
                case UserRoles.ADMIN:
                    rights = Rights.EMPLOYEE | Rights.CUSTOMER | Rights.SALES | Rights.STORAGE | Rights.PRODUCT | Rights.MANUFACTURE | Rights.REVIEWER | Rights.FIN;
                    break;
                case UserRoles.WORKER:
                default:
                    break;
            }

            return rights;
        }

    }
}
