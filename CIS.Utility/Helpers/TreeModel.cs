using System;

namespace CIS.Utility
{
    /// <summary>
    /// 通用树节点实体
    /// </summary>
    public class TreeModel
    {

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 父节点编码
        /// </summary>
        public string ParentCode { get; set; }
        /// <summary>
        /// 显示文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 用于类型树网格控件 填充单元格的值
        /// </summary>
        public object[] Cells { get; set; }
        /// <summary>
        /// 一般情况下存储实体对象
        /// </summary>
        public object Obj { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 判断是否为根节点
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsRootNode(string code)
        {
            string node = code.AsNotNullString();
            switch (node)
            {
                case "":
                case "ROOT":
                case "0":
                    return true;
                default:
                    return false;
            }
        }
    }

    public class TreeModel1
    {
        public string Code { get; set; }

        public string ParentCode { get; set; }

        public string Text { get; set; }

        public string Name { get; set; }

        public int Sort { get; set; }

        public int ImgIndex { get; set; }

        public object Obj { get; set; }
    }
}
