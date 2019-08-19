using System;
using System.Linq;

namespace EasyConsole
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public Program Program { get; set; }

        public Page(string title, Program program)
        {
            Title = title;
            Program = program;
        }

        public virtual void Display()
        {
            string line = null;

            if (Program.History.Count > 1 && Program.BreadcrumbHeader)
            {
                string breadcrumb = null;
                foreach (var title in Program.History.Select((page) => page.Title).Reverse())
                    breadcrumb += title + " > ";
                breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3);

                line = new String('-', breadcrumb.Length + 2);

                Console.WriteLine(line);
                Console.WriteLine(breadcrumb);
                Console.WriteLine(line);
            }
            else
            {
                line = new String('-', Title.Length + 2);

                Console.WriteLine(line);
                Console.WriteLine(Title);
                Console.WriteLine(line);
            }

            Console.WriteLine();
        }
    }
}