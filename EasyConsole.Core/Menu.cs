using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyConsole
{
    public class Menu
    {
        #region Private Properties

        private IList<Option> _options { get; set; }

        #endregion Private Properties

        #region Public Constructors

        public Menu()
        {
            _options = new List<Option>();
        }

        public void Display()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Options[i].Name);
            }

            Console.WriteLine();
            int choice = Input.ReadInt("Selecione uma opção:", min: 1, max: Options.Count);

        #region Public Methods

        public Menu Add(string option, Action callback)
        {
            return Add(new Option(option, callback));
        }

        public Menu Add(Option option)
        {
            _options.Add(option);
            return this;
        }

        public bool Contains(string option)
        {
            return _options.FirstOrDefault((op) => op.Name.Equals(option)) != null;
        }

        public void Display()
        {
            for (int i = 0; i < _options.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, _options[i].Name);
            }
            int choice = Input.ReadInt("Choose an option:", min: 1, max: _options.Count);

            _options[choice - 1].Callback();
        }

        #endregion Public Methods
    }
}