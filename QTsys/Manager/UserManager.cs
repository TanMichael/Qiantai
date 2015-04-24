using QTsys.Common;
using QTsys.DAO;
using QTsys.DataObjects;

namespace QTsys.Manager
{
    class UserManager
    {
        private UserDAO dao;
        public UserManager()
        {
            this.dao = new UserDAO();
        }

        public static UserManager getUserManager()
        {
            return new UserManager();
        }
        
        public bool Login(User user)
        {
            bool result = false;
            // md5 password
            user.Password = Utils.GetMD5String(user.Password);

            var rUser = this.dao.GetUserByUserName(user.UserName);

            if (user.Password == rUser.Password)
            {
                result = true;
            }
            //var rs = resultObj.Status == "failed"  ? false : true;

            // TODO SET COOKIE

            return result;    // resultObj.success;
        }

        


    }
}
