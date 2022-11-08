using System;

namespace CIS.ControlLib.Controls.TemperatureChart
{
    public class ViewDragEventArgs:EventArgs
    {
        public ViewDragType DragType { get; private set; }

        public object OldData { get; private set; }

        public object DragData { get; private set; }

        public ViewDragEventArgs(ViewDragType dragType,object oldData,object dragData)
        {
            this.DragType = dragType;
            this.OldData = oldData;
            this.DragData = dragData;
        }
    }
}
