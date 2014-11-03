using TodoYouToo.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoYouToo.Tests.Utilities
{
    class MockableOverdueColorConverter:OverdueColorConverter
    {
        private DateTime mockedDate;
        public MockableOverdueColorConverter(DateTime mockedDate)
            : base()
        {
            this.mockedDate = mockedDate;
        }

        protected override DateTime GetCurrentDate()
        {
            return mockedDate;
        }
    }
}
