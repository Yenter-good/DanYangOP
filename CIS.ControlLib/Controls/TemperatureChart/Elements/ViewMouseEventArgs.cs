using System;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    // 摘要:
    //     为 System.Windows.Forms.Control.MouseUp、System.Windows.Forms.Control.MouseDown
    //     和 System.Windows.Forms.Control.MouseMove 事件提供数据。
    [ComVisible(true)]
    public class ViewMouseEventArgs : EventArgs
    {
        // 摘要:
        //     初始化 System.Windows.Forms.MouseEventArgs 类的新实例。
        //
        // 参数:
        //   button:
        //     System.Windows.Forms.MouseButtons 值之一，它指示曾按下的是哪个鼠标按钮。
        //
        //   clicks:
        //     鼠标按钮曾被按下的次数。
        //
        //   x:
        //     鼠标单击的 x 坐标（以像素为单位）。
        //
        //   y:
        //     鼠标单击的 y 坐标（以像素为单位）。
        //
        //   delta:
        //     鼠标轮已转动的制动器数的有符号计数。
        //
        //   part:
        //     鼠标点击的视图部位
        //
        //   obj:
        //     鼠标点击的视图部位对应的对象
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public ViewMouseEventArgs(MouseButtons button, int clicks, float viewX, float viewY, int delta,ViewParts part,object obj)
        {
            this.Button = button;
            this.Clicks = clicks;
            this.ViewX = viewX;
            this.ViewY = viewY;
            this.Part = part;
            this.Object = obj;
        }
        /// <summary>
        /// 视图部位
        /// </summary>
        public ViewParts Part { get;private set; }

        public object Object { get; private set; }

        // 摘要:
        //     获取曾按下的是哪个鼠标按钮。
        //
        // 返回结果:
        //     System.Windows.Forms.MouseButtons 值之一。
        public MouseButtons Button { get; private set; }
        //
        // 摘要:
        //     获取按下并释放鼠标按钮的次数。
        //
        // 返回结果:
        //     一个 System.Int32，包含按下并释放鼠标按钮的次数。
        public int Clicks { get; private set; }
        //
        // 摘要:
        //     获取鼠标轮已转动的制动器数的有符号计数。制动器是鼠标轮的一个凹口。
        //
        // 返回结果:
        //     鼠标轮已转动的制动器数的有符号计数。
        public int Delta { get; private set; }
        //
        // 摘要:
        //     获取鼠标在产生鼠标事件时的位置。
        //
        // 返回结果:
        //     一个 System.Drawing.Point，其中包含鼠标相对于窗体左上角的 x 坐标和 y 坐标（以像素为单位）。
        public Point Location { get; private set; }
        //
        // 摘要:
        //     获取鼠标在产生鼠标事件时的 x 坐标。
        //
        // 返回结果:
        //     鼠标的 X 坐标（以像素为单位）。
        public float ViewX { get; private set; }
        //
        // 摘要:
        //     获取鼠标在产生鼠标事件时的 y 坐标。
        //
        // 返回结果:
        //     鼠标的 Y 坐标（以像素为单位）。
        public float ViewY { get; private set; }
    }
}
