using Caliburn.Micro;
using Specflow.specs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TodoYouToo.Interfaces;

namespace Specflow.specs.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        [BeforeScenario]
        public static void ReloadBootstrapper()
        {
            new AppBootstrapper();
            DateTimeProvider.MockedDate = new DateTime(2014, 01, 01);
        }

    }
}
