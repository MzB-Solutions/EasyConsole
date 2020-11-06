namespace EasyConsole
{
    public abstract class MenuPage : Page
    {
        #region Protected Properties

        protected Menu Menu { get; set; }

        #endregion Protected Properties

        #region Public Constructors

        public MenuPage(string title, Program program, params Option[] options)
            : base(title, program)
        {
            Menu = new Menu();

            foreach (var option in options)
                Menu.Add(option);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Display()
        {
            base.Display();

            if (Program.NavigationEnabled && !Menu.Contains("Voltar"))
                Menu.Add("Voltar", () => { Program.NavigateBack(); });

            Menu.Display();
        }

        #endregion Public Methods
    }
}