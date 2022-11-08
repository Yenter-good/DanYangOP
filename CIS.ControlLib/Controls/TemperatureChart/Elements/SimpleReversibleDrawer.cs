using System;
using System.Drawing;
using System.Runtime.InteropServices;
namespace CIS.ControlLib.Controls.TemperatureChart
{
	[ComVisible(false)]
	public class SimpleReversibleDrawer
	{
		public static void DrawReversibleLine(IntPtr hwnd, int int_0, int int_1, int int_2, int int_3)
		{
			IntPtr intPtr = SimpleReversibleDrawer.CreatePen(0, 1, ColorTranslator.ToWin32(Color.SkyBlue));
			IntPtr dC = SimpleReversibleDrawer.GetDC(hwnd);
			if (dC != IntPtr.Zero)
			{
				IntPtr intptr_ = SimpleReversibleDrawer.SelectObject(dC, intPtr);
				int int_4 = SimpleReversibleDrawer.SetROP2(dC, 7);
				SimpleReversibleDrawer.MoveToEx(dC, int_0, int_1, 0);
				SimpleReversibleDrawer.LineTo(dC, int_2, int_3);
				SimpleReversibleDrawer.SetROP2(dC, int_4);
				SimpleReversibleDrawer.SelectObject(dC, intptr_);
				SimpleReversibleDrawer.ReleaseDC(hwnd, dC);
			}
			SimpleReversibleDrawer.DeleteObject(intPtr);
		}
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int DeleteObject(IntPtr intptr_0);
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr GetDC(IntPtr intptr_0);
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreatePen(int int_0, int int_1, int int_2);
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool LineTo(IntPtr intptr_0, int int_0, int int_1);
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool MoveToEx(IntPtr intptr_0, int int_0, int int_1, int int_2);
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int SetROP2(IntPtr intptr_0, int int_0);
	}
}
