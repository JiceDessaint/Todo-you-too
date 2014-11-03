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
    public class MainFixture
    {
        private IMain mainVM;
        public MainFixture()
        { 
            // We get a reference to the main viewModel
            mainVM = IoC.Get<IMain>();
        }

        public void ClickOnAddButton()
        {
            mainVM.ShowPopup();
        }

        public string AddTodoPopupVisibility()
        {
            return mainVM.IsAddPopupVisible ? "Visible" : "Hidden";
        }
    }
}
