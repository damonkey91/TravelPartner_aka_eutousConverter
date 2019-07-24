using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TravelPartner.Helpers;
using TravelPartner.Model;
using TravelPartner.ViewModel.Commands;
using Xamarin.Forms;

namespace TravelPartner.ViewModel
{
    class PopupViewModel : INotifyPropertyChanged, ITappedCallback
    {
        private ObservableCollection<Currency> currencies;
        private string searchText;
        private CurrencyConverterViewModel currencyViewModel;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Currency> Currencies
        {
            get => currencies; set
            {
                currencies = value;               
                OnPropertChanged("Currencies");
            }
        }

        public string SearchText
        {
            get => searchText; set
            {
                searchText = value;
                OnPropertChanged("SearchText");
            }
        }

        public TappCommand TappCommand { get; set; }

        public PopupViewModel(CurrencyConverterViewModel currencyViewModel)
        {
            PopulateObservableCollections();
            TappCommand = new TappCommand(this);
            this.currencyViewModel = currencyViewModel;
        }

        private async void PopulateObservableCollections()
        {
            List<Currency> allCurrencies = await App.Database.ReadAll();
            Currencies = allCurrencies != null ? new ObservableCollection<Currency>(allCurrencies) : new ObservableCollection<Currency>();
            
        }

        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Tapped(Currency clickedCurrency)
        {
            Currency oldCurrency = currencyViewModel.ClickedCurrency;
            List<Currency> list = ChangeOrder(oldCurrency, clickedCurrency);
            currencyViewModel.ReplaceCurrencyItem(list[1]);
            App.Database.UpdateAll(list);
            PopupNavigation.Instance.PopAsync();
        }

        private List<Currency> ChangeOrder(Currency oldCurrency, Currency newCurrency )
        {
            newCurrency.Order = oldCurrency.Order;
            oldCurrency.Order = Currency.NOT_CHOOSEN;
            return new List<Currency>() { oldCurrency, newCurrency };
        }
    }
}
