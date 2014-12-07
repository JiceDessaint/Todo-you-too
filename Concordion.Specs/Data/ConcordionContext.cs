using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo.Data;

namespace Concordion.Specs.Data
{
    public class ConcordionContext:DbContext, IContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
