namespace EasyConsole
{
    public static class StringExtensions
    {
        #region Public Methods

        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        #endregion Public Methods
    }
}