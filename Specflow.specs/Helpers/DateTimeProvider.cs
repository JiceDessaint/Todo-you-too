using TodoYouToo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.specs.Helpers
{
    public class DateTimeProvider:IDateTimeProvider
    {
        public static DateTime? MockedDate = null;
        public DateTime Now
        {
            get { return MockedDate.HasValue ? MockedDate.Value : DateTime.Now; }
        }
    }
}
