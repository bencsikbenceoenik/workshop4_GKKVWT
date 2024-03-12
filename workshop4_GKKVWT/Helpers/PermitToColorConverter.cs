using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace workshop4_GKKVWT.Helpers
{
    internal class PermitToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool l = bool.Parse(value.ToString());
            if(l == false)
            {
                return Brushes.Red;
            }
            //else if(l == true)
            //{
            //    return Brushes.HotPink;
            //}
            else
            {
                return Brushes.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
