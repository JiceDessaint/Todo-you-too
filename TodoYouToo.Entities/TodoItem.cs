using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoYouToo.Entities
{
    public class TodoItem
    {
        public int TodoItemID { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }

    }
}
