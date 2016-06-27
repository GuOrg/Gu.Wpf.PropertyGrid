namespace Gu.Wpf.PropertyGrid.Demo
{
    using System.Runtime.CompilerServices;

    public static class AutomationIds
    {
        public static readonly string MainWindowId = Create();

        private static string Create([CallerMemberName] string name = null)
        {
            return name;
        }
    }
}