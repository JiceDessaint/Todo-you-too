using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concordion.Integration;
using TodoYouToo.Entities;
using Concordion.Specs.Utilities;
using Caliburn.Micro;
using TodoYouToo;
using TodoYouToo.Data;

namespace Concordion.Specs
{
    [ConcordionTest]
    class AddTodoTest
    {
        private static AppBootstrapper bootstrapper;
        private IMain mainVM;
        private ITodoRepository repo;

        public AddTodoTest()
        {
            bootstrapper = new AppBootstrapper();
            repo = IoC.Get<ITodoRepository>();

            //bootstrapper.Initialize();
        }

        public String isAppRunning()
        {
            try {
                mainVM = IoC.Get<IMain>();
                return "running";
            }catch(Exception ex){
                return "The app could not start : " + ex.ToString();
            }
        }

        public String clearDb()
        {
            try
            {
                repo.RemoveAll();
                return "empty";
            }
            catch (Exception ex)
            {
                return "The db had a problem : " + ex.ToString();
            }
        }

        public void setTodayDate(String today)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            DateTimeProvider.MockedDate = DateTime.Parse(today, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            Console.Write(DateTimeProvider.MockedDate);
        }

        public String clickAddPopup()
        {
            try
            {
                mainVM.ShowPopup();
                return "clicked on the add popup";
            }
            catch (Exception ex)
            {
                return " Couldn't open the pop up " + ex.ToString();
            }
        }

        public void addTaskNamed(String name) {
            var popup = mainVM.AddTodoPopup;
            popup.Text = name;
            popup.Add();
        }

        public IEnumerable<TodoItem> getAllTasks()
        {
            return mainVM.TodoItems.ToArray();
        }

    }
}
