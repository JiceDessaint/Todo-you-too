using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TodoYouToo;
using TodoYouToo.Data;

namespace Specflow.specs.Helpers
{
    static class ApplicationHelper
    {

        public static IMain MainViewModel
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("MainViewModel"))
                    ScenarioContext.Current.Add("MainViewModel", IoC.Get<IMain>());
                return ScenarioContext.Current["MainViewModel"] as IMain;
            }
        }
    }
}
