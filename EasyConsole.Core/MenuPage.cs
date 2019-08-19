namespace EasyConsole
{
    public abstract class MenuPage : Page
    {
        protected Menu Menu { get; set; }

        public MenuPage(string title, Program program, params Option[] options)
            : base(title, program)
        {
            Menu = new Menu();

            foreach (var option in options)
                Menu.Add(option);
        }

        public override void Display()
        {
            base.Display();

            if (Program.NavigationEnabled && !Menu.Contains("Voltar"))
                Menu.Add("Voltar", () => { Program.NavigateBack(); });

            Menu.Display();
        }
    }
}