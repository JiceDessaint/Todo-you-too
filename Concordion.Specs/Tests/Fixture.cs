using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo;
using TodoYouToo.Data;
using TodoYouToo.Entities;

namespace Concordion.Specs.Tests
{
    class Fixture
    {
        private static AppBootstrapper bootstrapper;
        protected IMain mainVM;
        protected ITodoRepository repo;
        private static IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

        protected static DateTime ParseDate(String date)
        {
            return DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }

        public Fixture()
        {
            bootstrapper = new AppBootstrapper();
            repo = IoC.Get<ITodoRepository>();
            repo.RemoveAll();
        }

        public String isAppRunning()
        {
            try
            {
                mainVM = IoC.Get<IMain>();
                return "running";
            }
            catch (Exception ex)
            {
                return "The app could not start : " + ex.ToString();
            }
        }

        public String clearDb()
        {
            try
            {
                repo.RemoveAll();
                if (repo.GetAll().Count() == 0)
                {
                    mainVM.TodoItems.Clear();
                    return "empty";
                }
                else
                {
                    return "still " + repo.GetAll().Count() + " elems in the database";
                }
            }
            catch (Exception ex)
            {
                return "The db had a problem : " + ex.ToString();
            }
        }

        public void addTask(String name, String dueDate)
        {
            var popup = mainVM.AddTodoPopup;
            popup.Text = name;
            popup.Date = ParseDate(dueDate);
            popup.Add();
        }

        public IEnumerable<TodoItem> getAllTasks()
        {
            return mainVM.TodoItems.ToArray();
        }

    }
}
