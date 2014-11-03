using Caliburn.Micro;
using TodoYouToo;
using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnesse.Fixtures
{
    public class GetAllTodos
    {
        public List<Object> Query()
        {
            var result = new List<Object>();

            var main = IoC.Get<IMain>();
            foreach (var t in main.TodoItems)
                AddOneObject(result, t);
            return result;
        }

        private void AddOneObject(ICollection<object> objects, TodoItem item)
        {
            var objectFields = new List<object>();
            AddText(objectFields, item);
            AddDone(objectFields, item);
            AddDueDate(objectFields, item);
            objects.Add(objectFields);
        }

        private void AddText(List<object> objectDescription, TodoItem item)
        {
            AddFieldNameAndValue(objectDescription, "Text", item.Text);
        }

        private void AddDone(List<object> objectDescription, TodoItem item)
        {
            AddFieldNameAndValue(objectDescription, "Done", item.IsDone ? "YES" : "NO");
        }

        private void AddDueDate(List<object> objectDescription, TodoItem item)
        {
            AddFieldNameAndValue(objectDescription, "Due Date", item.DueDate.ToShortDateString());
        }

        private void AddFieldNameAndValue(List<object> objects, string name, string value)
        {
            var fieldNameValue = new List<Object>();
            fieldNameValue.Add(name);
            fieldNameValue.Add(value);
            objects.Add(fieldNameValue);
        }
    }
}
