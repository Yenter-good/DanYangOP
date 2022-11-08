using CIS.ControlLib.Drawing;
using System;
using System.Drawing;
using System.Globalization;

namespace CIS.ControlLib.Helper
{
    class GraphicsHelper
    {
        private static float _Dpi;

        static GraphicsHelper()
        {
            _Dpi = 96f;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                _Dpi = graphics.DpiX;
            }
        }

        #region 绘制形状

        /// <summary>
        /// 绘制符号
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clipRect"></param>
        /// <param name="centerX">中心X坐标</param>
        /// <param name="centerY">中心Y坐标</param>
        /// <param name="style">符号样式</param>
        /// <param name="color">符号颜色</param>
        /// <param name="symbolSize">符号大小</param>
        public static void DrawSymbol(Graphics g, float centerX, float centerY, SymbolStyle style, Color color, float symbolSize)
        {
            //float symbolPixelSize = GraphicsUnitConvert.Convert(symbolSize,GraphicsUnit.Pixel,g.PageUnit);

            RectangleF symbolRect = new RectangleF(centerX - symbolSize / 2f, centerY - symbolSize / 2f, symbolSize, symbolSize);

            float width = Convert(2f, GraphicsUnit.Pixel, g.PageUnit);

            switch (style)
            {
                case SymbolStyle.SolidCicle:
                    using (Brush brush = new SolidBrush(color))
                    {
                        g.FillEllipse(brush, symbolRect);
                    }
                    break;
                case SymbolStyle.HollowCicle:
                    using (Pen pen = new Pen(color, width))
                    {
                        g.DrawEllipse(pen, symbolRect);
                    }
                    break;
                case SymbolStyle.Cross:
                    using (Pen pen = new Pen(color, width))
                    {
                        g.DrawLine(pen, symbolRect.Left, symbolRect.Top, symbolRect.Right, symbolRect.Bottom);
                        g.DrawLine(pen, symbolRect.Left, symbolRect.Bottom, symbolRect.Right, symbolRect.Top);
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        /// <summary>
        /// 获取最优的字体
        /// </summary>
        /// <param name="g"></param>
        /// <param name="idealFont"></param>
        /// <param name="drawString"></param>
        /// <param name="limitSize"></param>
        /// <returns></returns>
        public static Font GetBestFont(Graphics g, Font idealFont, string drawString, SizeF limitSize, bool overrun = true)
        {
            SizeF size = g.MeasureString(drawString, idealFont);
            if ((overrun && (size.Width > limitSize.Width * 1.1 || size.Height > limitSize.Height * 1.1))
                || (!overrun && (size.Width > limitSize.Width || size.Height > limitSize.Height)))
            {
                return GetBestFont(g, new Font(idealFont.FontFamily, idealFont.Size - 0.1f, idealFont.Style, idealFont.Unit), drawString, limitSize);
            }
            return idealFont;
        }

        #region 单位转换

        /// <summary>
        /// 单位转换
        /// </summary>
        /// <param name="vValue"></param>
        /// <param name="OldUnit"></param>
        /// <param name="NewUnit"></param>
        /// <returns></returns>
        public static double Convert(double vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            double result;
            if (OldUnit == NewUnit)
            {
                result = vValue;
            }
            else
            {
                result = vValue * GetRate(NewUnit, OldUnit);
            }
            return result;
        }
       /// <summary>
       /// 单位装换
       /// </summary>
       /// <param name="vValue"></param>
       /// <param name="OldUnit"></param>
       /// <param name="NewUnit"></param>
       /// <returns></returns>
        public static float Convert(float vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            float result;
            if (OldUnit == NewUnit)
            {
                result = vValue;
            }
            else
            {
                result = (float)((double)vValue * GetRate(NewUnit, OldUnit));
            }
            return result;
        }
        /// <summary>
        /// 转换为厘米
        /// </summary>
        /// <param name="vValue"></param>
        /// <param name="oldUnit"></param>
        /// <returns></returns>
        public static float ConvertToCM(float vValue, GraphicsUnit oldUnit)
        {
            return (float)((double)Convert(vValue, oldUnit, GraphicsUnit.Millimeter) / 10.0);
        }
        /// <summary>
        /// 厘米转换为指定单位
        /// </summary>
        /// <param name="cmValue"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static float ConvertFromCM(float cmValue, GraphicsUnit unit)
        {
            return Convert(cmValue * 10f, GraphicsUnit.Millimeter, unit);
        }
        public static int Convert(int vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            int result;
            if (OldUnit == NewUnit)
            {
                result = vValue;
            }
            else
            {
                result = (int)((double)vValue * GetRate(NewUnit, OldUnit));
            }
            return result;
        }
        public static Point Convert(Point p, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            Point result;
            if (OldUnit == NewUnit)
            {
                result = p;
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                result = new Point((int)((double)p.X * rate), (int)((double)p.Y * rate));
            }
            return result;
        }
        public static PointF Convert(PointF p, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            PointF result;
            if (OldUnit == NewUnit)
            {
                result = p;
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                result = new PointF((float)((double)p.X * rate), (float)((double)p.Y * rate));
            }
            return result;
        }
        public static Point Convert(int x, int y, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            Point result;
            if (OldUnit == NewUnit)
            {
                result = new Point(x, y);
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                result = new Point((int)((double)x * rate), (int)((double)y * rate));
            }
            return result;
        }
        public static Size Convert(Size size, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            Size result;
            if (OldUnit == NewUnit)
            {
                result = size;
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                result = new Size((int)((double)size.Width * rate), (int)((double)size.Height * rate));
            }
            return result;
        }
        public static SizeF Convert(SizeF size, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            SizeF result;
            if (OldUnit == NewUnit)
            {
                result = size;
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                result = new SizeF((float)((double)size.Width * rate), (float)((double)size.Height * rate));
            }
            return result;
        }
        public static Rectangle Convert(Rectangle rect, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            Rectangle result;
            if (OldUnit == NewUnit)
            {
                result = rect;
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                result = new Rectangle((int)((double)rect.X * rate), (int)((double)rect.Y * rate), (int)((double)rect.Width * rate), (int)((double)rect.Height * rate));
            }
            return result;
        }
        public static RectangleF Convert(RectangleF rect, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            RectangleF result;
            if (OldUnit == NewUnit)
            {
                result = rect;
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                result = new RectangleF((float)((double)rect.X * rate), (float)((double)rect.Y * rate), (float)((double)rect.Width * rate), (float)((double)rect.Height * rate));
            }
            return result;
        }
        public static double GetRate(GraphicsUnit NewUnit, GraphicsUnit OldUnit)
        {
            return GetUnit(OldUnit) / GetUnit(NewUnit);
        }
        public static double GetDpi(GraphicsUnit unit)
        {
            double result;
            switch (unit)
            {
                case GraphicsUnit.Display:
                    result = (double)_Dpi;
                    break;
                case GraphicsUnit.Pixel:
                    result = (double)_Dpi;
                    break;
                case GraphicsUnit.Point:
                    result = 72.0;
                    break;
                case GraphicsUnit.Inch:
                    result = 1.0;
                    break;
                case GraphicsUnit.Document:
                    result = 300.0;
                    break;
                case GraphicsUnit.Millimeter:
                    result = 25.4;
                    break;
                default:
                    result = (double)_Dpi;
                    break;
            }
            return result;
        }
        public static double GetUnit(GraphicsUnit unit)
        {
            double result;
            switch (unit)
            {
                case GraphicsUnit.Display:
                    result = (double)(1f / _Dpi);
                    break;
                case GraphicsUnit.Pixel:
                    result = (double)(1f / _Dpi);
                    break;
                case GraphicsUnit.Point:
                    result = 0.013888888888888888;
                    break;
                case GraphicsUnit.Inch:
                    result = 1.0;
                    break;
                case GraphicsUnit.Document:
                    result = 0.0033333333333333335;
                    break;
                case GraphicsUnit.Millimeter:
                    result = 0.03937007874015748;
                    break;
                default:
                    throw new NotSupportedException("Not support " + unit.ToString());
            }
            return result;
        }
        
        public static int ToTwips(int Value, GraphicsUnit unit)
        {
            double unit2 = GetUnit(unit);
            return (int)((double)Value * unit2 * 1440.0);
        }
        public static int ToTwips(float Value, GraphicsUnit unit)
        {
            double unit2 = GetUnit(unit);
            return (int)((double)Value * unit2 * 1440.0);
        }
        public static int FromTwips(int Twips, GraphicsUnit unit)
        {
            double unit2 = GetUnit(unit);
            return (int)((double)Twips / (unit2 * 1440.0));
        }
        public static double FromTwips(double twips, GraphicsUnit unit)
        {
            double unit2 = GetUnit(unit);
            return twips / (unit2 * 1440.0);
        }
        public static double ParseCSSLength(string CSSLength, GraphicsUnit unit, double DefaultValue)
        {
            CSSLength = CSSLength.Trim();
            int length = CSSLength.Length;
            double vValue = 0.0;
            double result;
            for (int i = 0; i < length; i++)
            {
                char value = CSSLength[i];
                if ("-.0123456789".IndexOf(value) < 0)
                {
                    if (i > 0)
                    {
                        if (double.TryParse(CSSLength.Substring(0, i), NumberStyles.Any, null, out vValue))
                        {
                            string text = CSSLength.Substring(i).Trim().ToLower();
                            string text2 = text;
                            if (text2 != null)
                            {
                                if (!(text2 == "cm"))
                                {
                                    if (!(text2 == "mm"))
                                    {
                                        if (!(text2 == "in"))
                                        {
                                            if (!(text2 == "pt"))
                                            {
                                                if (!(text2 == "pc"))
                                                {
                                                    if (!(text2 == "px"))
                                                    {
                                                        goto IL_173;
                                                    }
                                                    result = Convert(vValue, GraphicsUnit.Pixel, unit);
                                                }
                                                else
                                                {
                                                    result = Convert(vValue, GraphicsUnit.Point, unit) * 12.0;
                                                }
                                            }
                                            else
                                            {
                                                result = Convert(vValue, GraphicsUnit.Point, unit);
                                            }
                                        }
                                        else
                                        {
                                            result = Convert(vValue, GraphicsUnit.Inch, unit);
                                        }
                                    }
                                    else
                                    {
                                        result = Convert(vValue, GraphicsUnit.Millimeter, unit);
                                    }
                                }
                                else
                                {
                                    result = Convert(vValue, GraphicsUnit.Millimeter, unit) * 10.0;
                                }
                                return result;
                            }
                        IL_173: ;
                        }
                    }
                }
            }
            if (double.TryParse(CSSLength, NumberStyles.Any, null, out vValue))
            {
                result = Convert(vValue, GraphicsUnit.Pixel, unit);
                return result;
            }
            result = DefaultValue;
            return result;
        }

        #endregion
    }


}
