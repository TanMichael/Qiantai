using System;
using System.IO;
using System.Net;
using QTsys.Common;

namespace QTsys.Rest
{
    class RestService
    {
        private static string url_base = Utils.GetUrlBase();

        public static string Get(string action, string parameters)
        {
            string result = "";

            HttpWebRequest request = WebRequest.Create(url_base + action) as HttpWebRequest;
            // Get response
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
            }

            return result;
        }

        public static string Post(string action, string data)
        {
            string result = "";

            Uri address = new Uri(url_base + action);
            // Create the web request
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "text/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var response = request.GetResponse() as HttpWebResponse;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
    }
}
