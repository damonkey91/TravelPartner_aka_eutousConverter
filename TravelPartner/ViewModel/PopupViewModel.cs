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
    class PopupViewModel : ViewModelBase, ITappedCallback, ISearchBarCallback
    {
        private ObservableCollection<Currency> currencies;
        private CurrencyConverterViewModel currencyViewModel;

        public ObservableCollection<Currency> Currencies
        {
            get => currencies;
            set => SetProperty(ref currencies, value);
        }

        public SearchCommand SearchBarCommand { get; set; }

        public TappCommand TappCommand { get; set; }

        public PopupViewModel(CurrencyConverterViewModel currencyViewModel)
        {
            PopulateObservableCollections();
            SearchBarCommand = new SearchCommand(this);
            TappCommand = new TappCommand(this);
            this.currencyViewModel = currencyViewModel;
        }

        private async void PopulateObservableCollections()
        {
            List<Currency> allCurrencies = await Currency.GetAllCurrencies();
            Currencies = allCurrencies != null ? new ObservableCollection<Currency>(allCurrencies) : new ObservableCollection<Currency>();
            
        }

        public void Tapped(Currency clickedCurrency)
        {
            Currency oldCurrency = currencyViewModel.ClickedCurrency;
            List<Currency> list = SetPosition(oldCurrency, clickedCurrency);
            currencyViewModel.ReplaceCurrencyItem(list[0]);
            ChoosenCurrenciesTable.Update(list);
            PopupNavigation.Instance.PopAsync();
        }

        public async void Search(string input)
        {
            List<Currency> searchResult;
            if (!string.IsNullOrEmpty(input))
                searchResult = await Currency.GetCurrenciesContaining(input);
            else
                searchResult = await Currency.GetAllCurrencies();
            Currencies = new ObservableCollection<Currency>(searchResult);
        }

        private List<Currency> SetPosition(Currency oldCurrency, Currency newCurrency )
        {
            newCurrency.Position = oldCurrency.Position;
            return new List<Currency>() { newCurrency };
        }

    }
}
