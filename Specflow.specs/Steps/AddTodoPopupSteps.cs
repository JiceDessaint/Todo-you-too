using Specflow.specs.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.specs.Steps
{
    [Binding]
    public class AddTodoPopupSteps
    {
        [Given(@"I enter ""(.*)"" in the textbox")]
        public void GivenIEnterInTheTextbox(string text)
        {
            ApplicationHelper.MainViewModel.AddTodoPopup.Text = text;
        }

        [Given(@"I enter ""(.*)"" as the date")]
        public void GivenIEnterAsTheDate(string date)
        {
            ApplicationHelper.MainViewModel.AddTodoPopup.Date = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture); ;
        }

        [When(@"I hit Enter")]
        [Given(@"I hit Enter")]
        public void GivenIHitEnter()
        {
            ApplicationHelper.MainViewModel.AddTodoPopup.Add();
        }

    }
}
