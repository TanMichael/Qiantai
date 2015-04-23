using System.Collections.Generic;
using Newtonsoft.Json;
using QTsys.Common;
using QTsys.DataObjects;
using QTsys.Rest;
using QTsys.DAO;

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

        public User GetUserById(string id)
        {
            string resultStr = RestService.Get("user/" + id, null);
            var resultObj = RestResult.ConvertToObject(resultStr);

            if (resultObj.Status == "success")
            {
                User user = User.ConvertToObject(resultObj.ResultJson);
                return user;
            }

            return null;
        }

        public List<User> ListUser(int page)
        {
            string action = "listUser/" + (page <= 0 ? "" : page.ToString());
            string resultStr = RestService.Get(action, null);
            var resultObj = RestResult.ConvertToObject(resultStr);

            if (resultObj.Status == "success")
            {
                List<User> users = User.ConvertToObjectList(resultObj.ResultJson);
                return users;
            }

            return null;
        }

        public User CreateUser(User user)
        {
            // md5 password
            user.Password = Utils.GetMD5String(user.Password);
            string postBody = User.ConvertToJson(user);

            string resultJson = RestService.Post("createUser", postBody);
            var resultObj = RestResult.ConvertToObject(resultJson);

            if (resultObj.Status == "success")
            {
                User retUser = User.ConvertToObject(resultObj.ResultJson);
                return retUser;
            }


            return null;
        }

        public string[] listUserName()
        {
           string action = "listUserName";
            string resultStr = RestService.Get(action, null);

            var resultObj = RestResult.ConvertToObject(resultStr);

            if (resultObj.Status == "success")
            {
                //User retUser = User.ConvertToObject(resultObj.ResultJson);
                string[] res = JsonConvert.DeserializeObject<string[]>(resultObj.ResultJson);
                return res;
            }

            return null;
        }
        




    }
}
