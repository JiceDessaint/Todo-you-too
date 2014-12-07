using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concordion.Integration;
using TodoYouToo.Entities;
using Concordion.Specs.Utilities;
using Caliburn.Micro;
using TodoYouToo;
using TodoYouToo.Data;

namespace Concordion.Specs.Tests
{
    [ConcordionTest]
    class AddTodoTest : Fixture
    {
        

        public void setTodayDate(String today)
        {

            DateTimeProvider.MockedDate = ParseDate(today);
        }

        public String clickAddPopup()
        {
            try
            {
                mainVM.ShowPopup();
                return "clicked on the plus button";
            }
            catch (Exception ex)
            {
                return " Couldn't open the pop up " + ex.ToString();
            }
        }

        public void addTaskNamed(String name) {
            var popup = mainVM.AddTodoPopup;
            popup.Text = name;
            popup.Add();
        }
      
        public String getPopupStatus()
        {
            return mainVM.IsAddPopupVisible ? "open" : "closed";
        }

    }
}
