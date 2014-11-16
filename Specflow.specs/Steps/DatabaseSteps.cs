using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TodoYouToo.Data;
using TodoYouToo.Entities;

namespace Specflow.specs
{
    [Binding]
    public class DatabaseSteps
    {
        [Given(@"I have deleted the database")]
        public void GivenIHaveDeletedTheDatabase()
        {
            IoC.Get<ITodoRepository>().RemoveAll();
        }

        [Given(@"I have a todo database filled with")]
        public void GivenIHaveATodoDatabaseFilledWith(Table table)
        {
            GivenIHaveDeletedTheDatabase();
            var repo = IoC.Get<ITodoRepository>();
            foreach (var row in table.Rows)
            {
                var todoItem = new TodoItem();
                if (table.Header.Contains("Done"))
                    todoItem.IsDone = row["Done"] == "YES";
                if (table.Header.Contains("Text"))
                    todoItem.Text = row["Text"];
                if (table.Header.Contains("Due Date"))
                    todoItem.DueDate = DateTime.ParseExact(row["Due Date"], "dd/MM/yyyy", CultureInfo.CurrentCulture);
                repo.Add(todoItem);
            }
            repo.SaveChanges();
        }
    }
}
