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
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
