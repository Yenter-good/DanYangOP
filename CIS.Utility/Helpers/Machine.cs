namespace CIS.Utility
{
    public static class Machine
    {
        public static string GetMachineIP()
        {
            return System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString();
        }
    }
}
