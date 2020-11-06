using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EasyConsole
{
    public abstract class Program
    {
        #region Private Properties

        private Dictionary<Type, Page> _pages { get; set; }

        #endregion Private Properties

        #region Protected Constructors

        protected Program(string title, bool breadcrumbHeader)
        {
            Title = title;
            _pages = new Dictionary<Type, Page>();
            History = new Stack<Page>();
            BreadcrumbHeader = breadcrumbHeader;
        }

        #endregion Protected Constructors

        #region Protected Properties

        protected Page CurrentPage
        {
            get
            {
                return (History.Any()) ? History.Peek() : null;
            }
        }

        protected string Title { get; set; }

        #endregion Protected Properties

        #region Public Properties

        public bool BreadcrumbHeader { get; private set; }
        public Stack<Page> History { get; private set; }

        public bool NavigationEnabled { get { return History.Count > 1; } }

        #endregion Public Properties

        #region Public Methods

        public void AddPage(Page page)
        {
            Type pageType = page.GetType();

            if (_pages.ContainsKey(pageType))
                _pages[pageType] = page;
            else
                _pages.Add(pageType, page);
        }

        public Page NavigateBack()
        {
            History.Pop();

            Console.Clear();
            CurrentPage.Display();
            return CurrentPage;
        }

        public void NavigateHome()
        {
            while (History.Count > 1)
                History.Pop();

            Console.Clear();
            CurrentPage.Display();
        }

        public T NavigateTo<T>() where T : Page
        {
            SetPage<T>();

            Console.Clear();
            CurrentPage.Display();
            return CurrentPage as T;
        }

        public virtual void Run()
        {
            try
            {
                Console.Title = Title;

                CurrentPage.Display();
            }
            catch (Exception e)
            {
                Output.WriteLine(ConsoleColor.Red, e.ToString());
            }
            finally
            {
                if (Debugger.IsAttached)
                {
                    Input.ReadString("Pressione [Enter] para finalizar");
                }
            }
        }

        public T SetPage<T>() where T : Page
        {
            Type pageType = typeof(T);

            if (CurrentPage != null && CurrentPage.GetType() == pageType)
                return CurrentPage as T;

            // select the new page
            if (!_pages.TryGetValue(pageType, out Page nextPage))
                throw new KeyNotFoundException("The given page \"{0}\" was not present in the program".Format(pageType));

            // enter the new page
            History.Push(nextPage);

            return CurrentPage as T;
        }

        #endregion Public Methods
    }
}