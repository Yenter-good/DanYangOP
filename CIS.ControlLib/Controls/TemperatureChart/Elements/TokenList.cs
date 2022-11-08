using System;
using System.Collections.Generic;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// 标记集合
    /// </summary>
    [Serializable]
    public class TokenList : List<Token>, ICloneable
    {
        public Token GetItemByName(string name)
        {
            Token result;
            foreach (Token current in this)
            {
                if (current.Name == name)
                {
                    result = current;
                    return result;
                }
            }
            result = null;
            return result;
        }

        public object Clone()
        {
            TokenList tokenList = new TokenList();
            foreach (var item in this)
            {
                tokenList.Add((Token)item.Clone());
            }
            return tokenList;
        }
    }
}
