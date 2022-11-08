using Newtonsoft.Json.Converters;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace CIS.Utility
{
    public static class SerializeHelper
    {
        public static string BeginJsonSerializable(this object Obj, bool includeDefaultValue = false, bool includeNullValue = false)
        {
            if (Obj == null) return "";
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            Newtonsoft.Json.JsonSerializerSettings jsettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                Converters = new[] { timeFormat }
                    ,
                DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            };
            if (includeDefaultValue)
                jsettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
            if (includeNullValue)
                jsettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;

            return Newtonsoft.Json.JsonConvert.SerializeObject(Obj
                , Newtonsoft.Json.Formatting.None
                , jsettings);
        }

        public static T BeginJsonDeserialize<T>(this string str)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str)) return default(T);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
            }
            catch
            {
                return default(T);
            }
        }

        public static string BeginXMLSerializable(object sourceObj)
        {
            using (StringWriter writer = new StringWriter())
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(sourceObj.GetType());
                XmlSerializerNamespaces nameSpace = new XmlSerializerNamespaces();

                nameSpace.Add("", "");
                xmlSerializer.Serialize(writer, sourceObj, nameSpace);
                return writer.ToString();
            }
        }

        public static T BeginXMLDeserialize<T>(string xml) where T : class, new()
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(typeof(T));
                return xmldes.Deserialize(sr) as T;
            }
        }

        public static byte[] BeginSerializable(this object Obj)
        {
            MemoryStream mStream = new MemoryStream();
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(mStream, Obj);
            return mStream.GetBuffer();
        }

        public static T BeginDeserialize<T>(this byte[] Bytes)
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            return (T)bFormatter.Deserialize(new MemoryStream(Bytes));
        }
    }
}
