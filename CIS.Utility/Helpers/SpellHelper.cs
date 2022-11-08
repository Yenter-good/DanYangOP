using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace CIS.Utility
{
    /// <summary>
    /// 拼音五笔码帮助类
    /// </summary>
    public class SpellHelper
    {
        private static XmlDocument document = new XmlDocument();

        private static System.Collections.Hashtable values = new System.Collections.Hashtable();

        static SpellHelper()
        {
            try
            {
                document.LoadXml(Properties.Resources.SPELL1);
                XmlNodeList nodeList = document.SelectNodes("/ROWDATA/ROW");
                foreach (XmlNode item in nodeList)
                {
                    if (!values.ContainsKey(item["NAME"].InnerText))
                        values.Add(item["NAME"].InnerText, new SpellInfo() { Name = item["NAME"].InnerText, Pinyin = item["SPELL_CODE"].InnerText, Wubi = item["WB_CODE"].InnerText });
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 获取中文的拼音码
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string GetSpells(string strText)
        {
            string myStr = "";
            try
            {
                int len = strText.Length;
                for (int i = 0; i < len; i++)
                {
                    myStr += GetSpell(strText.Substring(i, 1));
                }
            }
            catch
            {
                myStr = "";
            }
            return myStr;
        }

        /// <summary>
        /// 获取单个字的拼音码
        /// </summary>
        /// <param name="cnChar"></param>
        /// <returns></returns>
        private static string GetSpell(string cnChar)
        {
            if (values.ContainsKey(cnChar))
                return ((SpellInfo)values[cnChar]).Pinyin;
            else
                return string.Empty;
        }

        /// <summary>
        /// 获取五笔码
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string GetWuBis(string strText)
        {
            string myStr = "";
            try
            {
                int len = strText.Length;
                for (int i = 0; i < len; i++)
                {
                    myStr += GetWuBi(strText.Substring(i, 1));
                }
            }
            catch (Exception)
            {
                myStr = "";
            }
            return myStr;
        }

        /// <summary>
        /// 获取单个字的五笔码
        /// </summary>
        /// <param name="cnChar"></param>
        /// <returns></returns>
        private static string GetWuBi(string cnChar)
        {
            if (values.ContainsKey(cnChar))
                return ((SpellInfo)values[cnChar]).Wubi;
            else
                return string.Empty;
        }
    }
    [Serializable]
    public struct SpellInfo
    {
        /// <summary>
        /// 汉字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string Pinyin { get; set; }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string Wubi { get; set; }
    }
}
public static class EcanConvertToCh
{
    /// <summary>

    /// 在指定的字符串列表CnStr中检索符合拼音索引字符串

    /// </summary>

    /// <param name="CnStr">汉字字符串</param>

    /// <returns>相对应的汉语拼音首字母串</returns>

    public static string GetSpellCode(this string CnStr)
    {

        string strTemp = "";

        int iLen = CnStr.Length;

        int i = 0;

        for (i = 0; i <= iLen - 1; i++)
        {

            strTemp += GetCharSpellCode(CnStr.Substring(i, 1));

        }

        return strTemp;

    }

    /// <summary>
    /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
    /// </summary>
    /// <param name="CnChar">单个汉字</param>
    /// <returns>单个大写字母</returns>

    private static string GetCharSpellCode(string CnChar)
    {

        long iCnChar;

        byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

        //如果是字母，则直接返回

        if (ZW.Length == 1)
        {

            return CnChar.ToUpper();

        }

        else
        {

            // get the array of byte from the single char

            int i1 = (short)(ZW[0]);

            int i2 = (short)(ZW[1]);

            iCnChar = i1 * 256 + i2;

        }

        // iCnChar match the constant

        if ((iCnChar >= 45217) && (iCnChar <= 45252))
        {

            return "A";

        }

        else if ((iCnChar >= 45253) && (iCnChar <= 45760))
        {

            return "B";

        }
        else if ((iCnChar >= 45761) && (iCnChar <= 46317))
        {

            return "C";

        }
        else if ((iCnChar >= 46318) && (iCnChar <= 46825))
        {

            return "D";

        }
        else if ((iCnChar >= 46826) && (iCnChar <= 47009))
        {

            return "E";

        }
        else if ((iCnChar >= 47010) && (iCnChar <= 47296))
        {

            return "F";

        }
        else if ((iCnChar >= 47297) && (iCnChar <= 47613))
        {

            return "G";

        }
        else if ((iCnChar >= 47614) && (iCnChar <= 48118))
        {

            return "H";

        }
        else if ((iCnChar >= 48119) && (iCnChar <= 49061))
        {

            return "J";

        }
        else if ((iCnChar >= 49062) && (iCnChar <= 49323))
        {

            return "K";

        }
        else if ((iCnChar >= 49324) && (iCnChar <= 49895))
        {

            return "L";

        }
        else if ((iCnChar >= 49896) && (iCnChar <= 50370))
        {

            return "M";

        }
        else if ((iCnChar >= 50371) && (iCnChar <= 50613))
        {

            return "N";

        }
        else if ((iCnChar >= 50614) && (iCnChar <= 50621))
        {

            return "O";

        }
        else if ((iCnChar >= 50622) && (iCnChar <= 50905))
        {

            return "P";

        }
        else if ((iCnChar >= 50906) && (iCnChar <= 51386))
        {

            return "Q";

        }
        else if ((iCnChar >= 51387) && (iCnChar <= 51445))
        {

            return "R";

        }
        else if ((iCnChar >= 51446) && (iCnChar <= 52217))
        {

            return "S";

        }
        else if ((iCnChar >= 52218) && (iCnChar <= 52697))
        {

            return "T";

        }
        else if ((iCnChar >= 52698) && (iCnChar <= 52979))
        {

            return "W";

        }
        else if ((iCnChar >= 52980) && (iCnChar <= 53640))
        {

            return "X";

        }
        else if ((iCnChar >= 53689) && (iCnChar <= 54480))
        {

            return "Y";

        }
        else if ((iCnChar >= 54481) && (iCnChar <= 55289))
        {

            return "Z";

        }
        else

            return ("Z");

    }
}
