using Client.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Client.Convertors
{
    class StringToColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == ServiceTaskStatusesEnum.StatusAssigned)
            {
                return Color.Red;
            }
            return Color.ForestGreen ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Color)value==Color.Red)
            {
                return ServiceTaskStatusesEnum.StatusAssigned;
            }
            return ServiceTaskStatusesEnum.StatusCompleted;
        }
    }
}
