using QTsys.Common;
using QTsys.DAO;
using QTsys.DataObjects;
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

        // TODO consider paging
        public DataTable GetAllCustomerMembers()
        {
            return this.customerDao.GetAllCustomerMembers();
        }

        public DataTable SearchCustomerByCol(string col, string name)//更新
        {
            return this.customerDao.SearchCustomerByCol(col, name);
        }

        public DataTable SearchCustomerMemberByCol(string col, string name)//更新
        {
            return this.customerDao.SearchCustomerMemberByCol(col, name);
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
