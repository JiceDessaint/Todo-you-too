using Specflow.specs.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.specs.Steps
{
    [Binding]
    public class ApplicationSteps
    {
        [When(@"I restart the application")]
        public void WhenIRestartTheApplication()
        {
            ScenarioHooks.ReloadBootstrapper();
        }
    }
}
