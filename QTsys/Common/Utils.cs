using QTsys.Common.Constants;
using QTsys.DataObjects;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;


namespace QTsys.Common
{
    static class Utils
    {
        private const string CONN_CONFIG_PATH = @"mysql_set.xml";
        private static LogonToken _logonToken = new LogonToken { Status = false, UserName = "", Name = "", Role = "" ,PWD=""};

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

        public static void SetLogonToken(User u, bool status = true)
        {
            _logonToken.UserName = u.UserName;
            _logonToken.Name = u.Name;  // 姓名
            _logonToken.Role = u.Role;
            _logonToken.Status = status;
            _logonToken.PWD = u.Password;
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
                    rights = Rights.PRODUCT | Rights.MANUFACTURE | Rights.REVIEWER;
                    break;
                case UserRoles.FOLLOW:
                    rights = Rights.SALES | Rights.PRODUCT | Rights.MANUFACTURE;
                    break;
                case UserRoles.STORAGE:
                    rights = Rights.STORAGE | Rights.PRODUCT;
                    break;
                case UserRoles.FINANCE:
                    rights = Rights.PRODUCT | Rights.FIN;    // TODO 对账单
                    break;
                case UserRoles.ADMIN:
                    rights = Rights.EMPLOYEE | Rights.CUSTOMER | Rights.SALES | Rights.STORAGE | Rights.PRODUCT | Rights.MANUFACTURE | Rights.REVIEWER | Rights.FIN ;
                    break;
                case UserRoles.WORKER:
                default:
                    break;
            }

            return rights;
        }

        public static string GetTemplateContent(string path)
        {
            string content;
            using (StreamReader rd = new StreamReader(path, Encoding.Default))
            {
                content = rd.ReadToEnd();
            }
            return content;
        }

        public static void WriteToTemplate(string path, string content)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                sw.Write(content);
            }
        }

        public static string GetTableTD(string value)
        {
            try
            {
                string html = "";
                if (value == "")
                {
                    html = "<td width=80 style='width:59.65pt;border:solid black 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:14.2pt'>" +
                                  "<p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><spanstyle='font-size:12.0pt;font-family:宋体'>" +
                                  "&nbsp;" + "</span></p></td>";
                }
                else
                {
                    html = "<td width=80 style='width:59.65pt;border:solid black 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:14.2pt'>" +
                               "<p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><spanstyle='font-size:12.0pt;font-family:宋体'>" +
                               value + "</span></p></td>";
                }
                return html;
            }
            catch (Exception ex)
            {
                string html = "<td width=80 style='width:59.65pt;border:solid black 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:14.2pt'>" +
                                  "<p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><spanstyle='font-size:12.0pt;font-family:宋体'>"
                                  + "</span></p></td>";
                return html;
            }
            
        }

        public static string GetTableTR(string[] tds)
        {
            string html = "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:14.2pt'>";
            foreach (string td in tds)
            {
                html += td;
            }
            html += "</tr>";
            return html;
        }

        public static string GetTableTrex(string tr)
        {
            string html = "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:14.2pt'>";
            html += tr;
          //  html += "</tr>";
            return html;
        }
    }
}
