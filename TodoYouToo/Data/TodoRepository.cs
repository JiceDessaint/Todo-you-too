using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo.Entities;

namespace TodoYouToo.Data
{
    public class TodoRepository: ITodoRepository
    {
        private IContext context;
        public TodoRepository(IContext context)
        {
            this.context = context;
        }

        public IEnumerable<Entities.TodoItem> GetAll()
        {
            return context.TodoItems;
        }

        public void Add(Entities.TodoItem item)
        {
            context.TodoItems.Add(item);
            context.SaveChanges();
        }

        public void Remove(Entities.TodoItem item)
        {
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
