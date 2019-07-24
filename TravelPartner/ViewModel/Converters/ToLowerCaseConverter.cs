﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TravelPartner.ViewModel.Converters
{
    class ToLowerCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";
            string lowercase = ((string)value).ToLower();
            return lowercase;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uppercase = ((string)value).ToUpper();
            return uppercase;
        }
    }
}
