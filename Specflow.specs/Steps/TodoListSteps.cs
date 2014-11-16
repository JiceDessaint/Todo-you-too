using NUnit.Framework;
using Specflow.specs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TodoYouToo.Entities;

namespace Specflow.specs.Steps
{
    [Binding]
    public class TodoListSteps
    {
        private string GetValueFromTodoForField(TodoItem item, string fieldName)
        {
            switch (fieldName)
            {
                case "Done": return item.IsDone ? "YES" : "NO";
                case "Text": return item.Text;
                case "Due Date": return item.DueDate.ToString("dd/MM/yyyy"); 
                default : Assert.Fail("Todo don't have a field called {0}", fieldName);break;
            }
            return string.Empty;
        }

        [Then(@"I should have todos on the screen with")]
        public void ThenIShouldHaveTodosOnTheScreenWith(Table table)
        {
            var todos = ApplicationHelper.MainViewModel.TodoItems;

            Assert.AreEqual(table.Rows.Count, todos.Count);

            for(var index = 0; index < todos.Count; index++)
            {
                var todoFromTable = table.Rows[index];
                var todoFromApp = todos[index];
                foreach (var header in table.Header)
                {
                    var fieldFromTable = todoFromTable[header];
                    var fieldFromTodo = this.GetValueFromTodoForField(todoFromApp, header);
                    Assert.AreEqual(fieldFromTodo, fieldFromTable);
                }
            }
        }

    }
}
