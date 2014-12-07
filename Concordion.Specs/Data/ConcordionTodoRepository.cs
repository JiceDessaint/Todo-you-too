using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo.Data;
using TodoYouToo.Entities;

namespace Concordion.Specs.Data
{
    public class ConcordionTodoRepository: ITodoRepository
    {
        private IContext context;
        public ConcordionTodoRepository(IContext context)
        {
            this.context = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return context.TodoItems;
        }

        public void Add(TodoItem item)
        {
            context.TodoItems.Add(item);
            context.SaveChanges();
        }

        public void Remove(TodoItem item)
        {
            context.TodoItems.Attach(item);
            context.TodoItems.Remove(item);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void RemoveAll()
        {
            foreach (var id in context.TodoItems.Select(e => e.TodoItemID))
            {
                var entity = new TodoItem { TodoItemID = id };
                context.TodoItems.Attach(entity);
                context.TodoItems.Remove(entity);
            }
            context.SaveChanges();
        }
    }
}
