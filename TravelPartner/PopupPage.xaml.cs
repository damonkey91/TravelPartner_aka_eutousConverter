using Rg.Plugins.Popup.Pages;
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
    public partial class MyPopupPage : PopupPage
    {
        private PopupViewModel viewModel;
        public MyPopupPage()
        {
            viewModel = new PopupViewModel();
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}