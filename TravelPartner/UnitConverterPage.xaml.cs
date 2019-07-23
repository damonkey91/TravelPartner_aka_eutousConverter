using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPartner.Helpers;
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
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Constants.GetCountries();
        }
    }
}