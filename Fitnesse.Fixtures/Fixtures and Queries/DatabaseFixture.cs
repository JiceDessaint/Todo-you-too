using Caliburn.Micro;
using TodoYouToo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo.Data;
using TodoYouToo.Entities;

namespace Fitnesse.Fixtures
{
    public class DatabaseFixture
    {
        public void DeleteAll()
        {
            IoC.Get<ITodoRepository>().RemoveAll();
        }

        public void PopulateWithSampleItems()
        {
            var repo = IoC.Get<ITodoRepository>();
            repo.RemoveAll();
            repo.Add(new TodoItem { Text = "Sample Todo 1", DueDate = new DateTime(2000, 01,01) });
            repo.Add(new TodoItem { Text = "Sample Todo 2", DueDate = new DateTime(2000, 01,01) });
            repo.Add(new TodoItem { Text = "Sample Todo 3", DueDate = new DateTime(2000, 01,01) });
        
        }

    }
}
