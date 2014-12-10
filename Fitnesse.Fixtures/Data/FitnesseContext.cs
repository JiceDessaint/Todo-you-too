using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo.Data;

namespace Fitnesse.Fixtures.Data
{
    public class FitnesseContext:Context, IContext
    {
        public FitnesseContext()
            : base("Fitnesse")
        {

        }
    }
}
