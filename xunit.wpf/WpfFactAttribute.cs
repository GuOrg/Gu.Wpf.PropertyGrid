namespace xunit.wpf
{
    using System;
    using Xunit;
    using Xunit.Sdk;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("xunit.wpf.WpfFactDiscoverer", "xunit.wpf")]
    public class WpfFactAttribute : FactAttribute
    {
    }
}
