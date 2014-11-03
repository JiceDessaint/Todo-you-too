using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnesse.Fixtures
{
    public class ApplicationFixture
    {
        public void Restart()
        {
            (new InitializeFixture()).InitializeApplication();
        }
    }
}
