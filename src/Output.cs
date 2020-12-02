using System;

namespace EasyConsole
{
    public static class Output
    {
        #region Public Methods

        public static void DisplayPrompt(string format, params object[] args)
        {
            format = format.Trim() + " ";
            Console.Write(format, args);
        }

        public static void WriteLine(ConsoleColor color, ConsoleColor bg, string format, params object[] args)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bg;
            Console.WriteLine(format, args);
            Console.ResetColor();
        }

        public static void WriteLine(ConsoleColor color, string format, params object[] args)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(format, args);
            Console.ResetColor();
        }

        public static void WriteLine(ConsoleColor color, ConsoleColor bg, string value)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = bg;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void WriteLine(ConsoleColor color, string value)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        #endregion Public Methods
    }
}