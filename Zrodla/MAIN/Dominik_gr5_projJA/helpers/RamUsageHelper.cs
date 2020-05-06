namespace ColorToGrayScale.helpers
{
    public class RamUsageHelper
    {
        private const int RamMBUsageWarning = 1000; //in MB

        public string RamUsage()
        {
            System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
            double memory = System.Math.Round(proc.PrivateMemorySize64 / 1e+6, 0);
            proc.Dispose();

            return memory.ToString();
        }
    }
}