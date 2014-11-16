using NUnit.Framework;
using Specflow.specs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.specs.Steps
{
    [Binding]
    public class MainScreenSteps
    {
        [Given(@"I click on New Todo button")]
        public void GivenIClickOnNewTodoButton()
        {
            ApplicationHelper.MainViewModel.ShowPopup();
        }

        [Given(@"I check the todo with text ""(.*)""")]
        public void GivenICheckTheTodoWithText(string text)
        {
            var main = ApplicationHelper.MainViewModel;
            var item = main.TodoItems.Where(t => t.Text == text).SingleOrDefault();
            if (item == null)
                Assert.Fail("Unable to find item with text '{0}'", text);
            item.IsDone = true;
            main.SaveTodo(item);
        }


    }
}
