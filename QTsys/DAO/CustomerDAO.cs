using MySql.Data.MySqlClient;
using QTsys.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DAO
{
    class CustomerDAO : DAOBase
    {
        /*
        public User GetUserByUserName(string userName)
        {
            User user = new User();
            string sql = "SELECT * FROM qiaotai.员工信息 WHERE 账户名='" + userName + "';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var rs = dt.Rows[0];

                user.Id = rs[0].ToString();
                user.UserName = rs[1].ToString();
                user.Password = rs[2].ToString();
                user.Name = rs[3].ToString();
                user.Role = rs[4].ToString();
                user.JobTitle = rs[5].ToString();
                user.Mobile = rs[6].ToString();
                user.Phone = rs[7].ToString();
                user.Email = rs[8].ToString();
                user.Department = rs[9].ToString();
            }

            this.Connection.Close();
            
            return user;
        }*/

        // TODO consider paging
        public DataTable GetAllCustomers()//更新
        {
            Customer cus = new Customer();
            string sql = "SELECT * FROM qiaotai.客户信息;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        // TODO consider paging
        public DataTable GetAllCustomerMembers()//更新
        {
            Customer cus = new Customer();
            string sql = "SELECT * FROM qiaotai.客户联系人;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }
        public DataTable SearchCustomerByCol(string Col, string Name)//更新
        {
            Customer cus = new Customer();
            string sql = "SELECT * FROM qiaotai.客户信息 WHERE "+Col+" LIKE '%" + Name + "%';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }
        public DataTable SearchCustomerMemberByCol(string Col, string Name)//更新
        {
            Customer cus = new Customer();
            string sql = "SELECT * FROM qiaotai.客户联系人 WHERE " + Col + " LIKE '%" + Name + "%';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }
        public bool AddNewCustomer(Customer cus)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.客户信息(客户名称,地址,联系电话,传真,电子邮箱,结算方式,流水号,备注) VALUES ('" + cus.Name + "','" + cus.Address + "','" + cus.Phone + "','" + cus.Fax + "','" + cus.Email + "','" + cus.Accounts + "','" + cus.Serial + "','" + cus.Remarks + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection); 
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) {  return false; }
        }

        public bool DelCustomer(String key)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.客户信息 WHERE 客户编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool AltCustomer(Customer cus)
        {
            try
            {
                string sql = "UPDATE qiaotai.客户信息 SET 客户编号='" + cus.Id + "',客户名称='" + cus.Name + "',地址='" + cus.Address + "',联系电话='" + cus.Phone + "',传真='" + cus.Fax + "',电子邮箱='" + cus.Email + "',结算方式='" + cus.Accounts + "',流水号='" + cus.Serial + "',备注='" + cus.Remarks + "' WHERE 客户编号='" + cus.Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }


        public bool AddNewCustomerMember(CustomerMember cus)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.客户联系人(编号,姓名,类型,联系电话,电子邮件,所属客户编号) VALUES ('" + cus.Id + "','" + cus.Name + "','" + cus.Type + "','" + cus.Phone + "','" + cus.Email + "','" + cus.CustomerId + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool DelCustomerMember(String key)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.客户联系人 WHERE 编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool AltCustomerMember(CustomerMember cus)
        {
            try
            {
                string sql = "UPDATE qiaotai.客户联系人 SET 编号='" + cus.Id + "',姓名='" + cus.Name + "',类型='" + cus.Type + "',联系电话='" + cus.Phone + "',电子邮件='" + cus.Email + "',所属客户编号='" + cus.CustomerId + "' WHERE 编号='" + cus.Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }






    }
}