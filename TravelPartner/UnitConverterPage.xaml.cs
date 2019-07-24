﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPartner.Helpers;
using TravelPartner.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelPartner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitConverterPage : ContentPage
    {
        public UnitConverterPage()
        {
            InitializeComponent();
            BindingContext = new CurrencyConverterViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Constants.GetCountries();
        }
    }
}