using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CIS.Utility
{
    public class XMLHelper
    {
        private const string BaseEntryChars = " <>&\"'￠£¥€§©®™×÷";
        public const string XML_Stylesheet = "xml-stylesheet";
        public const string XMLContentType = "text/xml";
        public const string XslNamespaceURI = "http://www.w3.org/1999/XSL/Transform";
        private static Dictionary<Type, string> _NativeXmlName = new Dictionary<Type, string>();

        public static string ToXMLEntry(string text)
        {
            string result;
            if (string.IsNullOrEmpty(text))
            {
                result = text;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    char c = text[i];
                    if (c > '\u007f' || " <>&\"'￠£¥€§©®™×÷".IndexOf(c) >= 0)
                    {
                        stringBuilder.Append("&#x" + Convert.ToInt32(c).ToString("X") + ";");
                    }
                    else
                    {
                        stringBuilder.Append(c);
                    }
                }
                result = stringBuilder.ToString();
            }
            return result;
        }

        public static string AllToXMLEntry(string text)
        {
            string result;
            if (string.IsNullOrEmpty(text))
            {
                result = text;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    char value = text[i];
                    stringBuilder.Append("&#x" + Convert.ToInt32(value).ToString("X") + ";");
                }
                result = stringBuilder.ToString();
            }
            return result;
        }

        public static string ToXMLEntryRandom(string text, double rate)
        {
            string result;
            if (string.IsNullOrEmpty(text))
            {
                result = text;
            }
            else
            {
                Random random = new Random();
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    char value = text[i];
                    if (random.NextDouble() < rate || " <>&\"'￠£¥€§©®™×÷".IndexOf(value) >= 0)
                    {
                        stringBuilder.Append("&#x" + Convert.ToInt32(value).ToString("X") + ";");
                    }
                    else
                    {
                        stringBuilder.Append(value);
                    }
                }
                result = stringBuilder.ToString();
            }
            return result;
        }

        public static string CleanupXMLHeader(string xmlText)
        {
            string result;
            if (string.IsNullOrEmpty(xmlText))
            {
                result = xmlText;
            }
            else
            {
                int num = xmlText.IndexOf("?>");
                if (num >= 0 && num < 50)
                {
                    num = xmlText.IndexOf("<", num + 1);
                    if (num > 0)
                    {
                        xmlText = xmlText.Substring(num);
                    }
                }
                result = xmlText;
            }
            return result;
        }

        public static string SaveObjectToXMLString(object instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.None;
            XMLHelper.SaveObjectToXMLWriter(instance, xmlTextWriter);
            xmlTextWriter.Close();
            string xmlText = stringWriter.ToString();
            return XMLHelper.CleanupXMLHeader(xmlText);
        }

        public static string SaveObjectToIndentXMLString(object instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.Indentation = 3;
            xmlTextWriter.IndentChar = ' ';
            XMLHelper.SaveObjectToXMLWriter(instance, xmlTextWriter);
            xmlTextWriter.Close();
            string xmlText = stringWriter.ToString();
            return XMLHelper.CleanupXMLHeader(xmlText);
        }

        public static object LoadObjectFromXMLString(Type type, string xml)
        {
            object result;
            if (string.IsNullOrEmpty(xml))
            {
                result = null;
            }
            else
            {
                StringReader stringReader = new StringReader(xml);
                XmlTextReader reader = new XmlTextReader(stringReader);
                object obj = XMLHelper.LoadObjectFromXMLReader(type, reader);
                stringReader.Close();
                result = obj;
            }
            return result;
        }

        public static object LoadObjectFromXMLReader(Type type, XmlTextReader reader)
        {
            reader.Normalization = false;
            object result;
            if (type.IsPrimitive || type.Equals(typeof(string)) || type.Equals(typeof(DateTime)))
            {
                reader.ReadStartElement();
                string value = reader.ReadElementString();
                result = Convert.ChangeType(value, type);
            }
            else
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                object obj = xmlSerializer.Deserialize(reader);
                result = obj;
            }
            return result;
        }

        public static void SaveObjectToXMLFile(object instance, string fileName)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            using (StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                XmlTextWriter writer = new XmlTextWriter(streamWriter);
                XMLHelper.SaveObjectToXMLWriter(instance, writer);
            }
        }

        public static void SaveObjectToXMLWriter(object instance, XmlTextWriter writer)
        {
            Type type = instance.GetType();
            if (type.IsPrimitive || type.Equals(typeof(string)) || type.Equals(typeof(DateTime)))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Value");
                writer.WriteString(Convert.ToString(instance));
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            else
            {
                XmlSerializer xmlSerializer = new XmlSerializer(instance.GetType());
                xmlSerializer.Serialize(writer, instance);
            }
        }

        public static object LoadObjectFromXMLFile(Type type, string fileName)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }
            object result;
            using (StreamReader streamReader = new StreamReader(fileName, Encoding.UTF8, true))
            {
                XmlTextReader reader = new XmlTextReader(streamReader);
                object obj = XMLHelper.LoadObjectFromXMLReader(type, reader);
                result = obj;
            }
            return result;
        }

        public static object LoadObjectUseXMLSerialize(string FileName, Type ObjectType)
        {
            if (FileName == null || FileName.Length == 0)
            {
                throw new ArgumentNullException("FileName");
            }
            if (ObjectType == null)
            {
                throw new ArgumentNullException("ObjectType");
            }
            object result;
            if (!File.Exists(FileName))
            {
                result = null;
            }
            else
            {
                XmlTextReader xmlTextReader = new XmlTextReader(FileName);
                XmlSerializer xmlSerializer = new XmlSerializer(ObjectType);
                object obj = xmlSerializer.Deserialize(xmlTextReader);
                xmlTextReader.Close();
                result = obj;
            }
            return result;
        }

        public static void SaveObjectUseXMLSerialize(string FileName, object ObjectValue)
        {
            if (FileName == null || FileName.Length == 0)
            {
                throw new ArgumentNullException("FileName");
            }
            if (ObjectValue == null)
            {
                throw new ArgumentNullException("ObjectValue");
            }
            if (File.Exists(FileName))
            {
                File.SetAttributes(FileName, FileAttributes.Normal);
            }
            XmlTextWriter xmlTextWriter = new XmlTextWriter(FileName, Encoding.UTF8);
            xmlTextWriter.IndentChar = ' ';
            xmlTextWriter.Indentation = 3;
            xmlTextWriter.Formatting = Formatting.Indented;
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectValue.GetType());
            xmlSerializer.Serialize(xmlTextWriter, ObjectValue);
            xmlTextWriter.Close();
        }

        public static string FormatXMLString(XmlNode node)
        {
            return XMLHelper.FormatXMLString(node, ' ', 3);
        }

        public static string FormatXMLString(XmlNode node, char IndentChar, int Indentation)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.IndentChar = IndentChar;
            xmlTextWriter.Indentation = Indentation;
            xmlTextWriter.Formatting = Formatting.Indented;
            node.WriteTo(xmlTextWriter);
            xmlTextWriter.Close();
            return XMLHelper.CleanupXMLHeader(stringWriter.ToString());
        }

        public static string FormatXMLString(string strXML, char IndentChar, int Indentation)
        {
            StringReader input = new StringReader(strXML);
            StringWriter stringWriter = new StringWriter();
            XmlTextReader xmlTextReader = new XmlTextReader(input);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Indentation = Indentation;
            xmlTextWriter.IndentChar = IndentChar;
            if (Indentation > 0)
            {
                xmlTextWriter.Formatting = Formatting.Indented;
            }
            else
            {
                xmlTextWriter.Formatting = Formatting.None;
            }
            xmlTextWriter.WriteStartDocument();
            while (xmlTextReader.Read())
            {
                XmlNodeType nodeType = xmlTextReader.NodeType;
                XmlNodeType xmlNodeType = nodeType;
                switch (xmlNodeType)
                {
                    case XmlNodeType.Element:
                        {
                            bool isEmptyElement = xmlTextReader.IsEmptyElement;
                            xmlTextWriter.WriteStartElement(xmlTextReader.Prefix, xmlTextReader.Name, xmlTextReader.NamespaceURI);
                            while (xmlTextReader.MoveToNextAttribute())
                            {
                                xmlTextWriter.WriteAttributeString(xmlTextReader.Prefix, xmlTextReader.Name, xmlTextReader.NamespaceURI, xmlTextReader.Value);
                            }
                            if (isEmptyElement)
                            {
                                xmlTextWriter.WriteEndElement();
                            }
                            break;
                        }
                    case XmlNodeType.Attribute:
                    case XmlNodeType.EntityReference:
                    case XmlNodeType.Entity:
                        break;

                    case XmlNodeType.Text:
                        xmlTextWriter.WriteString(xmlTextReader.Value);
                        break;

                    case XmlNodeType.CDATA:
                        xmlTextWriter.WriteCData(xmlTextReader.Value);
                        break;

                    case XmlNodeType.ProcessingInstruction:
                        xmlTextWriter.WriteProcessingInstruction(xmlTextReader.Name, xmlTextReader.Value);
                        break;

                    case XmlNodeType.Comment:
                        xmlTextWriter.WriteComment(xmlTextReader.Value);
                        break;

                    default:
                        switch (xmlNodeType)
                        {
                            case XmlNodeType.EndElement:
                                xmlTextWriter.WriteEndElement();
                                break;
                        }
                        break;
                }
            }
            xmlTextReader.Close();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
            string xmlText = stringWriter.ToString();
            return XMLHelper.CleanupXMLHeader(xmlText);
        }

        public static bool AppendXMLValueByPath(XmlNode RootNode, string strPath, XmlNamespaceManager xmlNamespaceManager_0, string strValue)
        {
            XmlNode xmlNode = XMLHelper.CreateXMLNodeByPath(RootNode, strPath, 1, xmlNamespaceManager_0);
            bool result;
            if (xmlNode != null)
            {
                string text;
                if (xmlNode is XmlElement)
                {
                    text = xmlNode.InnerText;
                }
                else
                {
                    text = xmlNode.Value;
                }
                if (!text.IsNullOrWhiteSpace())
                {
                    text = text + "," + strValue;
                }
                else
                {
                    text = strValue;
                }
                if (xmlNode is XmlElement)
                {
                    xmlNode.InnerText = text;
                }
                else
                {
                    xmlNode.Value = text;
                }
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static bool SetXMLValueByPath(XmlNode RootNode, string strPath, XmlNamespaceManager xmlNamespaceManager_0, string strValue)
        {
            XmlNode xmlNode = XMLHelper.CreateXMLNodeByPath(RootNode, strPath, 1, xmlNamespaceManager_0);
            bool result;
            if (xmlNode != null)
            {
                if (xmlNode is XmlElement)
                {
                    xmlNode.InnerText = strValue;
                }
                else
                {
                    xmlNode.Value = strValue;
                }
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static string GetXMLValueByPath(XmlNode RootNode, string strPath, XmlNamespaceManager xmlNamespaceManager_0)
        {
            XmlNode xmlNode = XMLHelper.CreateXMLNodeByPath(RootNode, strPath, 0, xmlNamespaceManager_0);
            string result;
            if (xmlNode == null)
            {
                result = null;
            }
            else
            {
                if (xmlNode is XmlElement)
                {
                    result = xmlNode.InnerText;
                }
                else
                {
                    result = xmlNode.Value;
                }
            }
            return result;
        }

        public static XmlNode CreateXMLNodeByPath(XmlNode RootNode, string strPath, int Create, XmlNamespaceManager nsm)
        {
            if (Create != 0 && Create != 1 && Create != 2)
            {
                throw new ArgumentException("Create参数无效");
            }
            if (RootNode == null)
            {
                throw new ArgumentNullException("RootNode", "未指定根节点");
            }
            if (strPath == null)
            {
                throw new ArgumentNullException("strPath", "未指定路径");
            }
            XmlNode result;
            if (XmlReader.IsName(strPath))
            {
                if (Create == 0 || Create == 1)
                {
                    foreach (XmlNode xmlNode in RootNode.ChildNodes)
                    {
                        if (xmlNode.Name == strPath)
                        {
                            result = xmlNode;
                            return result;
                        }
                    }
                }
                if (Create == 1 || Create == 2)
                {
                    XmlElement xmlElement = RootNode.OwnerDocument.CreateElement(strPath);
                    RootNode.AppendChild(xmlElement);
                    result = xmlElement;
                    return result;
                }
            }
            XmlNode xmlNode2 = null;
            if (Create == 0 || Create == 1)
            {
                xmlNode2 = RootNode.SelectSingleNode(strPath, nsm);
                if (xmlNode2 != null)
                {
                    result = xmlNode2;
                    return result;
                }
                if (Create == 0)
                {
                    result = null;
                    return result;
                }
            }
            string[] array = strPath.Split(new char[]
	{
		'/'
	});
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                text = text.Trim();
                if (text.StartsWith("@"))
                {
                    text = text.Substring(1);
                    text = text.Trim();
                }
                if (!XmlReader.IsName(text))
                {
                    result = null;
                    return result;
                }
            }
            XmlDocument ownerDocument = RootNode.OwnerDocument;
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                text = text.Trim();
                if (text.StartsWith("@"))
                {
                    if (RootNode.Attributes == null)
                    {
                        result = null;
                        return result;
                    }
                    string text2 = text.Substring(1);
                    text2 = text2.Trim();
                    xmlNode2 = RootNode.Attributes[text2];
                    if (xmlNode2 == null)
                    {
                        xmlNode2 = ownerDocument.CreateAttribute(text2);
                        RootNode.Attributes.Append((XmlAttribute)xmlNode2);
                        break;
                    }
                }
                else
                {
                    bool flag = false;
                    if (i != array.Length - 1 || Create == 1)
                    {
                        foreach (XmlNode xmlNode3 in RootNode.ChildNodes)
                        {
                            if (xmlNode3.Name == text)
                            {
                                xmlNode2 = xmlNode3;
                                RootNode = xmlNode2;
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (!flag)
                    {
                        xmlNode2 = ownerDocument.CreateElement(text);
                        RootNode.AppendChild(xmlNode2);
                        RootNode = xmlNode2;
                    }
                }
            }
            result = xmlNode2;
            return result;
        }

        public void WriteXSLTProcess(XmlWriter writer, string strHref)
        {
            writer.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='" + strHref + "'");
        }

        public static XmlElement CreateXSLElement(XmlDocument xmlDocument_0, string strName)
        {
            XmlElement result;
            if (!strName.IsNullOrWhiteSpace())
            {
                result = xmlDocument_0.CreateElement("xsl:" + strName, "http://www.w3.org/1999/XSL/Transform");
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static XmlElement CreateXSLValueOf(XmlDocument xmlDoc, string strSelect)
        {
            XmlElement result;
            if (!strSelect.IsNullOrWhiteSpace())
            {
                XmlElement xmlElement = xmlDoc.CreateElement("xsl:value-of", "http://www.w3.org/1999/XSL/Transform");
                xmlElement.SetAttribute("select", strSelect);
                result = xmlElement;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static XmlElement CreateXSLForeach(XmlDocument xmlDocument_0, string strSelect)
        {
            XmlElement result;
            if (!strSelect.IsNullOrWhiteSpace())
            {
                XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:for-each", "http://www.w3.org/1999/XSL/Transform");
                xmlElement.SetAttribute("select", strSelect);
                result = xmlElement;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static XmlElement CreateXSLAttriubte(XmlDocument xmlDocument_0, string strName)
        {
            XmlElement result;
            if (!strName.IsNullOrWhiteSpace())
            {
                XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:attribute", "http://www.w3.org/1999/XSL/Transform");
                xmlElement.SetAttribute("name", strName);
                result = xmlElement;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static XmlElement CreateXSLText(XmlDocument xmlDocument_0, bool disable_output_escaping)
        {
            XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:text", "http://www.w3.org/1999/XSL/Transform");
            if (disable_output_escaping)
            {
                xmlElement.SetAttribute("disable-output-escaping", "yes");
            }
            else
            {
                xmlElement.SetAttribute("disable-output-escaping", "no");
            }
            return xmlElement;
        }

        public static XmlElement CreateXSLText(XmlDocument xmlDocument_0, bool disable_output_escaping, string Text)
        {
            XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:text", "http://www.w3.org/1999/XSL/Transform");
            if (disable_output_escaping)
            {
                xmlElement.SetAttribute("disable-output-escaping", "yes");
            }
            else
            {
                xmlElement.SetAttribute("disable-output-escaping", "no");
            }
            if (Text != null && Text.Length > 0)
            {
                if (Text.IndexOf(">") >= 0 || Text.IndexOf("<") >= 0 || Text.IndexOf("&") >= 0)
                {
                    xmlElement.AppendChild(xmlDocument_0.CreateCDataSection(Text));
                }
                else
                {
                    xmlElement.AppendChild(xmlDocument_0.CreateTextNode(Text));
                }
            }
            return xmlElement;
        }

        public static XmlElement CreateXSLVariable(XmlDocument xmlDocument_0, string strName, string Select)
        {
            XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:variable", "http://www.w3.org/1999/XSL/Transform");
            xmlElement.SetAttribute("name", strName);
            xmlElement.SetAttribute("select", Select);
            return xmlElement;
        }

        public static XmlElement CreateXSLOutput(XmlDocument xmlDocument_0, string strMethod, bool bolIndent)
        {
            XmlElement xmlElement = xmlDocument_0.CreateElement("xsl:output", "http://www.w3.org/1999/XSL/Transform");
            xmlElement.SetAttribute("method", strMethod);
            if (bolIndent)
            {
                xmlElement.SetAttribute("indent", "yes");
            }
            else
            {
                xmlElement.SetAttribute("indent", "no");
            }
            return xmlElement;
        }

        public static bool HasTextNode(XmlElement myElement)
        {
            bool result;
            foreach (XmlNode xmlNode in myElement.ChildNodes)
            {
                if (xmlNode.NodeType == XmlNodeType.CDATA || xmlNode.NodeType == XmlNodeType.Text || xmlNode.NodeType == XmlNodeType.Whitespace)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }

        public static bool AllChildIsTextNode(XmlElement myElement)
        {
            bool result;
            foreach (XmlNode xmlNode in myElement.ChildNodes)
            {
                if (xmlNode.NodeType != XmlNodeType.CDATA && xmlNode.NodeType != XmlNodeType.Text && xmlNode.NodeType != XmlNodeType.Whitespace)
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }

        public static XmlElement CreateXSLForeachChildElement(XmlElement RootElement, string strSelect)
        {
            XmlElement xmlElement = RootElement.OwnerDocument.CreateElement("xsl:for-each", "http://www.w3.org/1999/XSL/Transform");
            xmlElement.SetAttribute("select", strSelect);
            RootElement.AppendChild(xmlElement);
            return xmlElement;
        }

        public static XmlElement CreateChildElement(XmlElement RootElement, string strName, bool CreateElement)
        {
            if (RootElement == null)
            {
                throw new ArgumentNullException("RootElement");
            }
            if (strName == null)
            {
                throw new ArgumentNullException("strName");
            }
            XmlElement result;
            foreach (XmlNode xmlNode in RootElement.ChildNodes)
            {
                if (xmlNode.Name == strName)
                {
                    result = (xmlNode as XmlElement);
                    return result;
                }
            }
            if (CreateElement)
            {
                XmlElement xmlElement = RootElement.OwnerDocument.CreateElement(strName);
                RootElement.AppendChild(xmlElement);
                result = xmlElement;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static XmlNode GetChildNode(XmlElement RootElement, string strName)
        {
            if (RootElement == null)
            {
                throw new ArgumentNullException("RootElement");
            }
            if (strName == null)
            {
                throw new ArgumentNullException("strName");
            }
            XmlNode result;
            foreach (XmlNode xmlNode in RootElement.ChildNodes)
            {
                if (xmlNode.Name == strName)
                {
                    result = xmlNode;
                    return result;
                }
            }
            result = null;
            return result;
        }

        public static void RemoveAllChild(XmlElement myElement)
        {
            while (myElement.LastChild != null)
            {
                myElement.RemoveChild(myElement.LastChild);
            }
        }

        public static string FixXMLName(string strName, char FixChar)
        {
            string result;
            if (strName == null || strName.Length == 0)
            {
                result = null;
            }
            else
            {
                if (XmlReader.IsName(strName))
                {
                    result = strName;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    bool flag = true;
                    for (int i = 0; i < strName.Length; i++)
                    {
                        char c = strName[i];
                        if (XmlReader.IsName(c.ToString()))
                        {
                            stringBuilder.Append(c);
                        }
                        else
                        {
                            if (!flag && char.IsNumber(c))
                            {
                                stringBuilder.Append(c);
                            }
                            else
                            {
                                stringBuilder.Append(FixChar);
                            }
                        }
                        flag = false;
                    }
                    result = stringBuilder.ToString();
                }
            }
            return result;
        }

        public static string ToIndentXMLString(XmlNode node, char IndentChar, int Indentation, bool vRemoveXMLDeclear)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.Indentation = Indentation;
            xmlTextWriter.IndentChar = IndentChar;
            node.WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();
            string text = stringWriter.ToString();
            xmlTextWriter.Close();
            if (vRemoveXMLDeclear)
            {
                text = XMLHelper.CleanupXMLHeader(text);
            }
            return text;
        }

        private static string GetNativeXmlName(Type type_0)
        {
            if (!XMLHelper._NativeXmlName.ContainsKey(type_0))
            {
                string value = null;
                XmlTypeAttribute xmlTypeAttribute = (XmlTypeAttribute)Attribute.GetCustomAttribute(type_0, typeof(XmlTypeAttribute), true);
                if (xmlTypeAttribute != null)
                {
                    value = xmlTypeAttribute.TypeName;
                }
                if (string.IsNullOrEmpty(value))
                {
                    value = type_0.Name;
                }
                XMLHelper._NativeXmlName[type_0] = value;
            }
            return XMLHelper._NativeXmlName[type_0];
        }

        private XMLHelper()
        {
        }
    }
}