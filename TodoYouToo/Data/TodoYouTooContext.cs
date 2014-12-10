using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo.Data;

namespace TodoYouToo.Data
{
    public class TodoYouTooContext:Context, IContext
    {
        public TodoYouTooContext() : base("TodoYouToo") { }
    }
}
