namespace ColorToGrayScale.Helpers
{
    public static class RamUsageHelper
    {
        public static string RamUsage()
        {
            System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
            double memory = System.Math.Round(proc.PrivateMemorySize64 / 1e+6, 0);
            proc.Dispose();

            return memory.ToString();
        }
    }
}