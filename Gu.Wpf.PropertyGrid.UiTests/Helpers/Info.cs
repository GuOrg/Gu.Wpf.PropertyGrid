namespace Gu.Wpf.PropertyGrid.UiTests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    public static class Info
    {
        public static ProcessStartInfo ProcessStartInfo { get; } = CreateStartInfo();

        private static ProcessStartInfo CreateStartInfo()
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = GetExeFileName(),
                Arguments = "en",
                UseShellExecute = false,
                //CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            return processStartInfo;
        }

        private static string GetExeFileName()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var testDirestory = Path.GetDirectoryName(new Uri(assembly.CodeBase).AbsolutePath);
            var assemblyName = assembly.GetName().Name;
            var exeDirectoryName = assemblyName.Replace("UITests", "Demo");
            var exeDirectory = testDirestory.Replace(assemblyName, exeDirectoryName);
            var fileName = Path.Combine(exeDirectory, "Gu.Wpf.PropertyGrid.Demo.exe");

            return fileName;
        }
    }
}