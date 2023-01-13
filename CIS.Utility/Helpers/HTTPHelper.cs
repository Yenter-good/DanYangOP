using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace CIS.Utility
{
    public static class HTTPHelper
    {
        public static string HttpPost(string Url, string postDataStr)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);

            var data = Encoding.UTF8.GetBytes(postDataStr);

            request.Method = "POST";
            request.Timeout = 2000;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static T HttpPost<T>(string Url, string postDataStr)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);

            var data = Encoding.UTF8.GetBytes(postDataStr);

            request.Method = "POST";
            request.Timeout = 2000;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static bool HttpPost(string Url, string postDataStr, ContentType contentType, out string result)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);

            var data = Encoding.UTF8.GetBytes(postDataStr);

            request.Method = "POST";
            request.ContentType = contentType.GetDescription();
            request.ContentLength = data.Length;
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                result = responseString;
                return true;
            }
            catch (Exception ex)
            {
                result = "Post报错:" + ex.Message;
                return false;
            }
        }

        public static bool HttpPost(string Url, string postDataStr, Dictionary<string, string> header, ContentType contentType, out string result)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);

            var data = Encoding.UTF8.GetBytes(postDataStr);
            foreach (var head in header)
            {
                request.Headers.Add(head.Key, head.Value);
            }

            request.Method = "POST";
            request.ContentType = contentType.GetDescription();
            request.ContentLength = data.Length;
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                result = responseString;
                return true;
            }
            catch (Exception ex)
            {
                result = "Post报错:" + ex.Message;
                return false;
            }
        }

        public static string HTTPPost(string url, string data, Dictionary<string, string> header, string contentType)
        {
            HttpWebRequest webrequest =
                (HttpWebRequest)HttpWebRequest.Create(url);
            webrequest.Method = "POST";

            webrequest.ContentType = contentType; //无关的请求头在本文中都省略掉了

            foreach (var head in header)
            {
                webrequest.Headers.Add(head.Key, head.Value);
            }

            string postData = data;

            byte[] postdatabyte = Encoding.UTF8.GetBytes(postData);
            webrequest.ContentLength = postdatabyte.Length;
            Stream stream = webrequest.GetRequestStream();
            stream.Write(postdatabyte, 0, postdatabyte.Length);
            stream.Close();

            HttpWebResponse response = (HttpWebResponse)webrequest.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("gb2312")); 
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;


        }

        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        public static Bitmap HttpGet(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            Image img = Image.FromStream(myResponseStream);
            myResponseStream.Close();

            return img as Bitmap;
        }

        public enum ContentType
        {
            [EnumDescription("application/json")]
            Json,
            [EnumDescription("application/x-www-form-urlencoded")]
            Form
        }
    }
}
