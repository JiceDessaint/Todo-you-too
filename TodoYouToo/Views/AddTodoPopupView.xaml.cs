using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TodoYouToo
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class AddTodoPopupView : Border
    {
        public AddTodoPopupView()
        {
            InitializeComponent();
        }

        private void Border_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Hack.. No need to bring focus to ViewModel as it is not its concern
            // So let's go quick and dirty !
            if (this.Visibility == Visibility.Visible)
            {
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    Keyboard.Focus(todoText);
                }, DispatcherPriority.Render);
            }
        }
    }
}
