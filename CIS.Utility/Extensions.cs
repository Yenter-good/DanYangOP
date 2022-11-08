
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Drawing;
using CIS.Utility;
using System.Text;
using System.Security.Cryptography;

namespace System
{
    public static class Extensions
    {

        #region 类型转换
        public static string AsString(this object targetValue)
        {
            return !targetValue.IsNull() ? targetValue.ToString().Trim() : null;
        }
        public static string AsString(this Object targetValue, string defaultValue)
        {
            var value = targetValue.AsString();
            if (value.IsNullOrWhiteSpace())
                return defaultValue;
            return value;
        }
        public static string AsNotNullString(this Object targetValue)
        {
            return !targetValue.IsNull() ? targetValue.ToString().Trim() : "";
        }

        public static int? AsInt(this Object targetValue)
        {
            int? returnValue = null;
            if (targetValue.IsNull())
            {
                return returnValue;
            }
            if (targetValue.GetType().IsEnum)
            {
                return (int)targetValue;
            }
            int result = 0;
            int.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }
        public static int AsInt(this Object targetValue, int defalutValue)
        {
            return targetValue.AsInt().GetValueOrDefault(defalutValue);
        }

        public static long? AsLong(this Object targetValue)
        {
            long? returnValue = null;
            if (targetValue.IsNull())
            {
                return returnValue;
            }

            long result = 0;
            long.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }

        public static long AsLong(this Object targetValue, long defalutValue)
        {
            return targetValue.AsLong().GetValueOrDefault(defalutValue);
        }

        public static Boolean AsBoolean(this Object targetValue)
        {
            if (targetValue.IsNull())
                return false;
            if (targetValue is Boolean)
                return ((Boolean)targetValue);
            string booleanStr = targetValue.AsString();
            bool result = false;
            if (Boolean.TryParse(booleanStr, out result))
                return result;
            switch (booleanStr.ToUpper())
            {
                case "是":
                case "Y":
                case "YES":
                    return true;
                case "否":
                case "N":
                case "NO":
                    return false;
                default:
                    break;
            }
            return targetValue.AsInt(0) > 0;
        }

        public static Double? AsDouble(this Object targetValue)
        {
            Double? returnValue = null;
            if (targetValue.IsNull())
            {
                return returnValue;
            }

            Double result = 0;
            Double.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }
        public static Double AsDouble(this object targValue, double defaultValue)
        {
            return AsDouble(targValue).GetValueOrDefault(defaultValue);
        }

        public static float? AsFloat(this Object targetValue)
        {
            float? returnValue = null;
            if (targetValue.IsNull())
            {
                return returnValue;
            }

            float result = 0;
            float.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }
        public static float AsFloat(this Object targetValue, float defaultValue)
        {
            return targetValue.AsFloat().GetValueOrDefault(defaultValue);
        }
        public static decimal? AsDecimal(this Object targetValue)
        {
            decimal? returnValue = null;
            if (targetValue == DBNull.Value || targetValue == null)
            {
                return returnValue;
            }

            decimal result = 0;
            decimal.TryParse(targetValue.ToString(), out result);
            returnValue = result;

            return returnValue;
        }
        public static decimal AsDecimal(this Object targetValue, decimal defaultValue)
        {
            return targetValue.AsDecimal().GetValueOrDefault(defaultValue);
        }
        public static DateTime? AsDateTime(this Object targetValue)
        {
            DateTime? returnValue = null;
            if (!targetValue.IsNull())
            {
                DateTime date;
                if (DateTime.TryParse(targetValue.ToString(), out date))
                    returnValue = date;
            }
            return returnValue;
        }


        public static DateTime AsDateTime(this Object targetValue, DateTime defaultTime)
        {
            DateTime? returnValue = null;
            if (targetValue != DBNull.Value && targetValue != null)
            {
                DateTime date;
                if (DateTime.TryParse(targetValue.ToString(), out date))
                    returnValue = date;
            }
            return returnValue.GetValueOrDefault(defaultTime);
        }

        public static byte[] AsBytes(this Object targetValue)
        {
            return targetValue != DBNull.Value && targetValue != null ? (byte[])targetValue : null;
        }
        /// <summary>
        /// 枚举转字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<TEnum, string> EnumToDict<TEnum>(this Type enumType)
        {
            Dictionary<TEnum, string> dict = new Dictionary<TEnum, string>();
            if (!typeof(TEnum).IsEnum) return dict;
            foreach (var i in Enum.GetValues(enumType))
            {
                var a = i;
                dict.Add((TEnum)i, ((Enum)i).GetDescription());
            }
            return dict;
        }

        #endregion

        #region 字符串

        /// <summary>
        /// 字符串格式化
        /// </summary>
        /// <param name="valueFormat">格式化文本</param>
        /// <param name="paramters">参数值</param>
        /// <returns></returns>
        public static string FormatWith(this string valueFormat, params object[] paramters)
        {
            return string.Format(valueFormat, paramters);
        }
        /// <summary>
        /// 判定字符串是否为空
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
        /// <summary>
        ///  指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        /// <summary>
        /// 如果string 类型的值 为Null返回空字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string IsNullToString(string obj)
        {
            if (obj == null)
            {
                return "";
            }
            return obj;
        }

        /// <summary>
        /// 如果int 类型的值 为Null返回0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int IsNullToInt(int? obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 如果decima 类型的值 为Null返回double 类型的 0.0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double IsNullToInt(decimal? obj)
        {
            if (obj == null)
            {
                return 0.0;
            }
            return Convert.ToDouble(obj);
        }

        #endregion

        #region 日期
        /// <summary>
        /// 获取当前日期的开始时间
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime Start(this DateTime datetime)
        {
            return datetime.Date;
        }
        /// <summary>
        /// 获取当前日期的结束时间
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime End(this DateTime datetime)
        {
            return datetime.Date.AddDays(1).AddMilliseconds(-1);
        }
        /// <summary>
        /// 日期转字符
        /// yyyy-MM-dd
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToYMD(this DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 日期转字符
        /// yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToYMDHM(this DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd HH:mm");
        }
        /// <summary>
        /// 日期转字符
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToYMDHMS(this DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 日期转字符
        /// HH:mm
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToHM(this DateTime datetime)
        {
            return datetime.ToString("HH:mm");
        }
        /// <summary>
        /// 日期转字符
        /// HH:mm:ss
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToHMS(this DateTime datetime)
        {
            return datetime.ToString("HH:mm:ss");
        }
        /// <summary>
        /// 获取当前时间所在月份的起始时间
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfTheMonth(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, 1);
        }
        /// <summary>
        /// 获取当前时间所在月份的最后一刻时间
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime LastDayOfTheMonth(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, DateTime.DaysInMonth(datetime.Year, datetime.Month)).End();
        }
        #endregion

        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumeration)
        {
            Type type = enumeration.GetType();
            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());
            if (null != memInfo && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (null != attrs && attrs.Length > 0)
                {
                    return ((EnumDescription)attrs[0]).Text;
                }
            }
            return enumeration.ToString();
        }

        public static string ToBase64(this string str)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            //转成 Base64 形式的 System.String  
            str = Convert.ToBase64String(b);
            return str;
        }

        public static string ToMD5(this string sourceText, bool toUpper = false)
        {
            if (sourceText == null)
                return null;

            StringBuilder result = new StringBuilder();
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(sourceText));
                if (toUpper)
                    for (int i = 0; i < data.Length; i++)
                        result.Append(data[i].ToString("X2"));
                else
                    for (int i = 0; i < data.Length; i++)
                        result.Append(data[i].ToString("x2"));
            }

            return result.ToString();
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToDBC(this string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 12288)
                {
                    array[i] = (char)32;
                    continue;
                }
                if (array[i] > 65280 && array[i] < 65375)
                {
                    array[i] = (char)(array[i] - 65248);
                }
            }
            return new string(array);
        }
        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(this string input)
        {
            // 半角转全角：  
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 32)
                {
                    array[i] = (char)12288;
                    continue;
                }
                if (array[i] < 127)
                {
                    array[i] = (char)(array[i] + 65248);
                }
            }
            return new string(array);
        }
        /// <summary>
        /// 获取颜色16进制形式的名称
        /// 如#f00
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string Get16Name(this Color color)
        {
            string result;
            if (color.A == 255)
            {
                string text = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
                result = text;
            }
            else
            {
                string text = string.Concat(new string[]
                {
                    "#",
                    color.A.ToString("X2"),
                    color.R.ToString("X2"),
                    color.G.ToString("X2"),
                    color.B.ToString("X2")
                });
                result = text;
            }
            return result;
        }

        /// <summary>
        /// 移除结尾的零
        /// </summary>
        /// <param name="targetValue"></param>
        /// <returns></returns>
        public static string RemoveTailZero(this double targetValue)
        {
            return targetValue.ToString().TrimEnd('0').TrimEnd('.');
        }
        /// <summary>
        /// 移除结尾的零
        /// </summary>
        /// <param name="targetValue"></param>
        public static string RemoveTailZero(this float targetValue)
        {
            return targetValue.ToString().TrimEnd('0').TrimEnd('.');
        }
        /// <summary>
        /// 移除结尾的零
        /// </summary>
        /// <param name="targetValue"></param>
        public static string RemoveTailZero(this decimal targetValue)
        {
            return targetValue.ToString().TrimEnd('0').TrimEnd('.');
        }
        /// <summary>
        /// 判断对象是否为null
        /// </summary>
        /// <param name="targetValue"></param>
        /// <returns></returns>
        public static bool IsNull(this object targetValue)
        {
            return (targetValue == DBNull.Value || targetValue == null);
        }

        /// <summary>
        /// 设置控件值
        /// 允许跨线程设置
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="control"></param>
        /// <param name="setValue"></param>
        public static void SetValue<TControl>(this TControl control, Action<TControl> setValue) where TControl : System.Windows.Forms.Control
        {
            if (setValue == null) return;
            if (control.InvokeRequired)
                control.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    setValue(control);
                });
            else
                setValue(control);
        }

        /// <summary>
        /// 获得文本的拼音码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetSpell(this string text)
        {
            return CIS.Utility.SpellHelper.GetSpells(text.AsNotNullString());
        }

        /// <summary>
        /// 获取文本的五笔码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetWBM(this string text)
        {
            return CIS.Utility.SpellHelper.GetWuBis(text.AsNotNullString());
        }

        /// <summary>
        /// 给DataTable增加拼音列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="colName"></param>
        public static void AppendSpell(this DataTable dt, params string[] colName)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string item in colName)
            {
                if (dt.Columns.Contains(item))
                {
                    DataColumn dc = new DataColumn(item + "_Spell", typeof(string));
                    dict[item] = item + "_Spell";
                    dt.Columns.Add(dc);
                }
            }
            foreach (DataRow item in dt.Rows)
            {
                foreach (var item1 in dict)
                {
                    item[item1.Value] = item[item1.Key].AsString().GetSpell();
                }
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="control"></param>
        /// <param name="source">仅限DataTable与List集合对象</param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        /// <param name="createEmptyItem">创建空项的方法</param>
        public static void DataBind(this System.Windows.Forms.ListControl control, object source, string valueMember, string displayMember, object selectedValue, Func<object> createEmptyItem = null)
        {
            if (createEmptyItem != null)
            {
                object emptyItem = createEmptyItem();
                if (emptyItem is Data.DataRow && source is Data.DataTable)
                {
                    var datatable = source as Data.DataTable;
                    datatable.Rows.InsertAt(emptyItem as Data.DataRow, 0);
                }
                else if (source is System.Collections.IList)
                {
                    var list = source as System.Collections.IList;
                    list.Insert(0, emptyItem);
                }
            }
            control.ValueMember = valueMember;
            control.DisplayMember = displayMember;
            control.DataSource = source;

            if (selectedValue != null)
                control.SelectedValue = selectedValue;
        }

        /// <summary>
        /// 当对象为空的时候抛出异常
        /// </summary>
        /// <typeparam name="T">The calling class</typeparam>
        /// <param name="obj">The This object</param>
        /// <param name="text">The text to be written on the ArgumentNullException: [text] not allowed to be null</param>
        public static void ThrowIfArgumentIsNull<T>(this T obj, string text) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(text + " 不允许为null");

        }

        /// <summary>
        /// 是否操作模式
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsDesignMode(this System.Windows.Forms.Control ctl)
        {
            bool returnFlag = false;
#if DEBUG

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                returnFlag = true;
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() == "DEVENV")
            {
                returnFlag = true;
            }
#endif
            return returnFlag;
        }

        public static T Clone<T>(this T source) where T : class
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// 获得当前患者年龄数值
        /// </summary>
        /// <returns></returns>
        public static int GetAge(this string AgeStr)
        {
            char[] str = new char[] { '岁', '月', '日', '天' };
            string age = AgeStr;
            char[] chr = age.ToCharArray();
            for (int i = 0; i < chr.Length; i++)
            {
                if (str.Contains(chr[i]))
                {
                    string s = new string(chr, 0, i);
                    return (int)float.Parse(s);
                }

            }
            return 0;
        }

        public static object RunFunction(this Type type, string FunctionName, params object[] obj)
        {
            object result = null;
            MethodInfo mt = type.GetMethod(FunctionName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            if (mt != null)
                result = mt.Invoke(null, obj);
            else
                result = ("该功能未定义,调用失败");
            return result;
        }

        public static bool _In<T>(this T t, List<T> obj)
        {
            if (obj.Contains(t))
                return true;
            return false;
        }

        public static bool _In<T>(this T t, params T[] obj)
        {
            if (obj.Contains(t))
                return true;
            return false;
        }
        public static string CheckIDCard(this string cid)
        {
            string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "xinjiang", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            double iSum = 0;
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|x)$");
            System.Text.RegularExpressions.Match mc = rg.Match(cid);
            if (!mc.Success)
            {
                return "身份证号错误";
            }
            cid = cid.ToLower();
            cid = cid.Replace("x", "a");
            if (aCity[int.Parse(cid.Substring(0, 2))] == null)
            {
                return "错误地区";
            }
            try
            {
                DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            }
            catch
            {
                return "错误生日";
            }
            for (int i = 17; i >= 0; i--)
            {
                iSum += (System.Math.Pow(2, i) % 11) * int.Parse(cid[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);

            }
            if (iSum % 11 != 1)
                return "错误校验码";

            return "";
        }

    }
}
