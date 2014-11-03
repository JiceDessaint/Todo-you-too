using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoYouToo.Data
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();

        void Add(TodoItem item);

        void RemoveAll();

        void Remove(TodoItem item);
    }
}
