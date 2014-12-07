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
    class DeleteTodoTest : Fixture
    {
        public void deleteTaskNamed(String name) {
            try
            {
                var tasks = repo.GetAll().Where(i => i.Text == name);
                var taskLength = tasks.Count();
                if (taskLength > 1)
                    throw new Exception(taskLength + " task have this name.");
                else if (taskLength == 0)
                    throw new Exception("no tasks were selected");
                mainVM.RemoveTodo(tasks.First());
            }
            catch (Exception ex)
            {
                var ex2 = ex.ToString();
            }
        }
      

    }
}
