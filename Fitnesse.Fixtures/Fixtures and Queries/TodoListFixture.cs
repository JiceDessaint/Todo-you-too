using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo;

namespace Fitnesse.Fixtures
{
    public class TodoListFixture
    {
        public bool CheckItemWithText(string text)
        {
            var main = IoC.Get<IMain>();
            var item = main.TodoItems.Where(t => t.Text == text).SingleOrDefault();
            if (item == null)
                return false;
            item.IsDone = true;
            main.SaveTodo(item);
            return true;
        }
    }
}
