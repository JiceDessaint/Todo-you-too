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

namespace Concordion.Specs.Tests
{
    [ConcordionTest]
    class MarkTodoTest : Fixture
    {
        public void MarkTaskNamed(String name) {

                var item = mainVM.TodoItems.Where(t => t.Text == name).SingleOrDefault();
                if (item == null)
                    throw new Exception("can't find task");
                item.IsDone = true;
                mainVM.SaveTodo(item);

        }
      

    }
}
