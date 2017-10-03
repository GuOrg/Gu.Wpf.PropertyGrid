namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System.Diagnostics;
    using Gu.Wpf.UiAutomation;

    public static class Info
    {
        public static string ExeFileName { get; } = Application.FindExe("Gu.Wpf.PropertyGrid.Demo.exe");

        public static ProcessStartInfo ProcessStartInfo { get; } = CreateStartInfo(null);

        internal static ProcessStartInfo CreateStartInfo(string args)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = ExeFileName,
                Arguments = args,
                UseShellExecute = false,
                //CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            return processStartInfo;
        }
    }
}