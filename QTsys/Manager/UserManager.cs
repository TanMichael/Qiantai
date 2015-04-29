using QTsys.Common;
using QTsys.DAO;
using QTsys.DataObjects;
using System.Collections.Generic;
using System.Data;

namespace QTsys.Manager
{
    class UserManager
    {
        private UserDAO userDao;
        private CustomerDAO customerDao;

        public UserManager()
        {
            this.userDao = new UserDAO();
            this.customerDao = new CustomerDAO();
        }

        public static UserManager getUserManager()
        {
            return new UserManager();
        }
        
        public User Login(User user)
        {
            User result = null;
            // md5 password
            user.Password = Utils.GetMD5String(user.Password);

            var rUser = this.userDao.GetUserByUserName(user.UserName);

            if (user.Password == rUser.Password)
            {
                result = rUser;
            }
            //var rs = resultObj.Status == "failed"  ? false : true;

            // TODO SET COOKIE

            return result;    // resultObj.success;
        }

        public void UpdateConnection()
        {
            this.userDao = new UserDAO();
            this.customerDao = new CustomerDAO();
        }

        public DataTable GetAllUser()
        {
            return this.userDao.GetAllUser();
        }

        public DataTable SearchUserByCol(string col, string value)
        {
            return this.userDao.SearchUserByCol(col, value);
        }

        public bool AddNewUser(User user)
        {
            return this.userDao.AddNewUser(user);
        }

        public bool DelUser(string key)
        {
            return this.userDao.DelUser(key);
        }

        public bool UpdateUser(User user)
        {
            return this.userDao.AltUser(user);
        }

        # region customer management

        public DataTable GetAllCustomers()
        {
            return this.customerDao.GetAllCustomers();
        }

        public List<Customer> GetAllCustomerList()
        {
            List<Customer> customers = new List<Customer>();
            var dt =  this.customerDao.GetAllCustomers();

            var l = dt.Rows.Count;
            for (int i = 0; i < l; i++)
            {
                var rs = dt.Rows[i];
                Customer customer = new Customer();

                customer.Id = rs["客户编号"].ToString();
                customer.Name = rs["客户名称"].ToString();
                customer.Address = rs["地址"].ToString();
                customer.Phone = rs["联系电话"].ToString();
                customer.Fax = rs["传真"].ToString();
                customer.Email = rs["电子邮箱"].ToString();
                customer.PaymentMode = rs["结算方式"].ToString();
                customer.Serial = rs["流水号"].ToString();
                customer.Remarks = rs["备注"].ToString();

                customers.Add(customer);
            }

            return customers;
        }

        // TODO consider paging
        public DataTable GetCustomerMembersByCustomer(string cId)
        {
            return this.customerDao.GetCustomerMembersByCustomer(cId);
        }

        public DataTable SearchCustomerByCol(string col, string name)//更新
        {
            return this.customerDao.SearchCustomerByCol(col, name);
        }

        public DataTable SearchCustomerMemberByCol(string col, string name, string cId="")//更新
        {
            return this.customerDao.SearchCustomerMemberByCol(col, name, cId);
        }

        public bool AddNewCustomer(Customer cus)
        {
            return this.customerDao.AddNewCustomer(cus);
        }

        public bool DelCustomer(string key)
        {
            return this.customerDao.DelCustomer(key);
        }

        public bool UpdateCustomer(Customer cus)
        {
            return this.customerDao.AltCustomer(cus);
        }


        public bool AddNewCustomerMember(CustomerMember cus)
        {
            return this.customerDao.AddNewCustomerMember(cus);
        }

        public bool DelCustomerMember(string key)
        {
            return this.customerDao.DelCustomerMember(key);
        }

        public bool UpdateCustomerMember(CustomerMember cus)
        {
            return this.customerDao.AltCustomerMember(cus);
        }

        # endregion
    }
}
