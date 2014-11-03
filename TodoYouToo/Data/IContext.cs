using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoYouToo.Data
{
    public interface IContext
    {
        DbSet<TodoItem> TodoItems { get; set; }

        int SaveChanges();
    }
}
