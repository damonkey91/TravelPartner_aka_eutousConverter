using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPartner.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelPartner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrencyConverterPage : ContentPage
    {
        CurrencyConverterViewModel viewModel;
        public CurrencyConverterPage()
        {
            viewModel = new CurrencyConverterViewModel();
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            viewModel.EntryFocused( (Entry)sender, e);
        }
    }
}