using Client.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Client.Convertors
{
    class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == ServiceTaskStatusesEnum.StatusAssigned)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return ServiceTaskStatusesEnum.StatusAssigned;
            }
            return ServiceTaskStatusesEnum.StatusCompleted;
        }
    }
}
