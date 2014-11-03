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
        public void TypeTextOnTheTextboxAndHitEnter(string text)
        {
            var main = IoC.Get<IMain>();
            main.AddTodoPopup.Text = text;
            main.AddTodoPopup.Add();
        }
    }
}
