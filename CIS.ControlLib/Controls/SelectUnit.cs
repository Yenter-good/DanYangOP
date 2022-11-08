using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;

namespace CIS.ControlLib.Controls
{
    public class SelectUnit : System.Windows.Forms.Panel
    {
        public SelectUnit()
        {
            this.Size = new System.Drawing.Size(130, 33);
            UnitItem = "未定义/r/n未定义";
            Draw();
        }

        int LastX = 15;

        private string[] UnitName
        { get; set; }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Localizable(true)]
        public string UnitItem
        {
            get
            {
                return string.Join(Environment.NewLine, UnitName);
            }
            set
            {
                UnitName = value.Split(Environment.NewLine.ToCharArray());
                UnitName = UnitName.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                Draw();
            }
        }

        private void Draw()
        {
            System.Drawing.Graphics g = CreateGraphics();
            this.Controls.Clear();
            LastX = 15;
            for (int i = 0; i < UnitName.Length; i++)
            {
                string item = UnitName[i];
                System.Windows.Forms.RadioButton rb = new System.Windows.Forms.RadioButton();
                rb.Text = item;
                System.Drawing.SizeF size = g.MeasureString(item, this.Font);
                rb.Left = LastX;
                rb.Top = 8;
                rb.AutoSize = true;
                LastX += 20 + Convert.ToInt32(size.Width);
                this.Controls.Add(rb);
            }
            this.Width = LastX + 15;
        }
    }

    public class ItemBase
    {
        public string Text
        { get; set; }

        public bool Status
        { get; set; }

        public object Tag
        { get; set; }
    }
}
