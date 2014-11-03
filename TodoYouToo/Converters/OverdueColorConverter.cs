using Caliburn.Micro;
using TodoYouToo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace TodoYouToo.Converters
{
    public class OverdueColorConverter:IValueConverter
    {
        virtual protected DateTime GetCurrentDate()
        {
            return IoC.Get<IDateTimeProvider>().Now;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var date = value as DateTime?;
            var currentDate = this.GetCurrentDate();

            if (date != null && date < currentDate.Date)
                return new SolidColorBrush(Colors.Red);
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
