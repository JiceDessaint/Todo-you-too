using Caliburn.Micro;
using TodoYouToo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnesse.Fixtures
{
    public class AddTodoPopupFixture
    {
        private IAddTodoPopup popup;
        public AddTodoPopupFixture()
        {
            popup = IoC.Get<IMain>().AddTodoPopup;
        
        }

        public void SetDateTo(DateTime date)
        {
            popup.Date = date;
        }
        public void TypeTextOnTheTextboxAndHitEnter(string text)
        {
            popup.Text = text;
            popup.Add();
        }
    }
}
