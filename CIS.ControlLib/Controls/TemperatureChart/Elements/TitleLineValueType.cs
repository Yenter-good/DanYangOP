using System.Runtime.InteropServices;
namespace CIS.ControlLib.Controls.TemperatureChart
{
    /// <summary>
    /// ��ȡ�����ñ�������������
    /// </summary>
	[ComVisible(false)]
	public enum TitleLineValueType
	{
        /// <summary>
        /// ����
        /// </summary>
		SerialDate,
        /// <summary>
        /// ����
        /// </summary>
		InDayIndex,
        /// <summary>
        /// �ؼ���ʼ��������
        /// </summary>
		DayIndex,
        /// <summary>
        /// �̶�
        /// </summary>
		HourTick,
        /// <summary>
        /// �ı�
        /// </summary>
		Text,
        /// <summary>
        /// ��������
        /// </summary>
		Data,
        /// <summary>
        /// ��  ����������
        /// </summary>
        None
	}
}
