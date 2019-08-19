using System;

namespace EasyConsole
{
    public static class Input
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            int value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Por favor digite um inteiro entre {0} e {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }

        public static int ReadInt()
        {
            string input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Por favor insira um inteiro");
                input = Console.ReadLine();
            }

            return value;
        }

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum deve ser um tipo enumerado");

            Output.WriteLine(prompt);
            Menu menu = new Menu();

            TEnum choice = default;
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }
    }
}