using TodoYouToo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoYouToo.Data;

namespace Specflow.Specs.Data
{
    public class SpecflowContext:Context, IContext
    {
        public SpecflowContext()
            : base("Specflow")
        {

        }
    }
}
