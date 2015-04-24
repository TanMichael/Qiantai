﻿using MySql.Data.MySqlClient;
using QTsys.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DAO
{
    class UserDAO : DAOBase
    {
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
        }

        public DataTable GetAllUser()
        {
            User user = new User();
            string sql = "SELECT * FROM qiaotai.员工信息;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public List<string> GetAllUserNames()
        {
            List<string> result = new List<string>();

            string sql = "SELECT 账户名 FROM qiaotai.员工信息;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();

            int l = dt.Rows.Count;
            if (l > 0)
            {
                for (int i = 0; i < l; i++)
                {
                    result.Add(dt.Rows[i]["账户名"].ToString());
                }
            }


            return result;
        }

        public DataTable SearchUserByCol(string col, string value)
        {
            User user = new User();
            string sql = "SELECT * FROM qiaotai.员工信息 WHERE "+col+" LIKE '%" + value + "%';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public bool AddNewUser(User user)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.员工信息(员工编号,账户名,密码,姓名,系统角色,职位,手机,办公电话,电子邮箱,部门) VALUES ('" + user.Id + "','" + user.UserName + "','" + user.Password + "','" + user.Name + "','" + user.Role + "','" + user.JobTitle + "','" + user.Mobile + "','" + user.Phone + "','" + user.Email + "','" + user.Department + "');";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) {  return false; }
        }

        public bool DelUser(String key)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.员工信息 WHERE 员工编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool AltUser(User user)
        {
            try
            {
                string sql = "UPDATE qiaotai.员工信息 SET 员工编号='"+user.Id+"',账户名='"+user.UserName+"',姓名='"+user.Name+"',系统角色='"+user.Role+"',职位='"+user.JobTitle+"',手机='"+user.Mobile+"',办公电话='"+user.Phone+"',电子邮箱='"+user.Email+"',部门='"+user.Department+"' WHERE 员工编号='"+user.Id+"';";
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