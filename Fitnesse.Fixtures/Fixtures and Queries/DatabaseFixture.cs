using Caliburn.Micro;
using TodoYouToo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo.Data;

namespace Fitnesse.Fixtures
{
    public class DatabaseFixture
    {
        public void DeleteAll()
        {
            IoC.Get<ITodoRepository>().RemoveAll();
        }
    }
}
