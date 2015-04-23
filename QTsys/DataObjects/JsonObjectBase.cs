using Newtonsoft.Json;
using System.Collections.Generic;

namespace QTsys.DataObjects
{
    class JsonObjectBase<T>
    {
        public static string ConvertToJson(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ConvertToObject(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }

        public static List<T> ConvertToObjectList(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonStr);
        }
    }
}
