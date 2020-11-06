using System;

namespace EasyConsole
{
    public class Option
    {
        #region Public Constructors

        public Option(string name, Action callback)
        {
            Name = name;
            Callback = callback;
        }

        #endregion Public Constructors

        #region Public Properties

        public Action Callback { get; private set; }
        public string Name { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion Public Methods
    }
}