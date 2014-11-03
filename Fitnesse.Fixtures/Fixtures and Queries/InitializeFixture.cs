using Fitnesse.Fixtures.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnesse.Fixtures
{
    public class InitializeFixture
    {
        private static AppBootstrapper bootstrapper;
        public void InitializeApplication()
        { 
            // As xaml runtime is not loaded, we have to trigger by ourself the bootstrapper / ioc
            bootstrapper = new AppBootstrapper();
        }

        public void InitializeDate(DateTime date)
        {
            DateTimeProvider.MockedDate = date;
        }
    }
}
