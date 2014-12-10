using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoYouToo.Data
{
    public class Context:DbContext, IContext
    {
        public Context(string name):base(name) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
