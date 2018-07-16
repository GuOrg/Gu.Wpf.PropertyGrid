namespace Gu.Wpf.PropertyGrid
{
    /// <summary>
    /// Shared size group names used by the <see cref="PropertyGrid"/>.
    /// </summary>
    public static class SharedSizeGroups
    {
        /// <summary>
        /// Gets the header column group name.
        /// </summary>
        public static string HeaderColumn { get; } = nameof(HeaderColumn);

        /// <summary>
        /// Gets the value column group name.
        /// </summary>
        public static string ValueColumn { get; } = nameof(ValueColumn);

        /// <summary>
        /// Gets the suffix column group name.
        /// </summary>
        public static string SuffixColumn { get; } = nameof(SuffixColumn);
    }
}
