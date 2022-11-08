using System;

namespace CIS.Utility
{
    /// <summary>
    /// EnumDescription
    /// 枚举状态的说明。
    /// 
    /// 修改纪录

    /// </author> 
    /// </summary>    
    public class EnumDescription : Attribute
    {
        private string _text;

        public string Text
        {
            get
            {
                return _text;
            }
        }

        public EnumDescription(string text)
        {
            _text = text;
        }
    }
}
