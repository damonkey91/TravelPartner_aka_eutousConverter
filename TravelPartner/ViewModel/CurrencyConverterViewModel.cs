using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TravelPartner.Helpers;
using TravelPartner.Model;
using TravelPartner.ViewModel.Commands;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TravelPartner.ViewModel
{
    public class CurrencyConverterViewModel : ViewModelBase, ITappedCallback
    {
        private ObservableCollection<CurrencyListItemViewModel> choosenCurrencies;
        public ObservableCollection<CurrencyListItemViewModel> ChoosenCurrencies
        {
            get => choosenCurrencies;
            set => SetProperty(ref choosenCurrencies, value);
        }
        public TappCommand TappCommand { get; set; }
        private Entry focusedEntry = null;

        public Currency ClickedCurrency { get; private set; }

        public CurrencyConverterViewModel()
        {
            TappCommand = new TappCommand(this);
            PopulateObservableCollections();
            UpdateExchangeRate();
        }

        private async void UpdateExchangeRate()
        {
            if (CheckTimestamp()) {
                ExchangeRate exchangeRate = await ExchangeRate.GetExchangeRates();
                if (exchangeRate != null && exchangeRate.rates.Count != 0)
                {
                    Currency.UpdateCurrencyValue(exchangeRate);
                    PopulateObservableCollections();
                    Preferences.Set(Constants.TIMESTAMP_KEY, DateTime.Now);                   
                }
            }
        }

        private async void PopulateObservableCollections()
        {
            List<Currency> Currencies = await ChoosenCurrenciesTable.GetChoosenCurrencies(10);
            List<CurrencyListItemViewModel> tempCurrenciesList = new List<CurrencyListItemViewModel>();
            Currencies.ForEach(currency => tempCurrenciesList.Add(new CurrencyListItemViewModel(currency)));
            ChoosenCurrencies = new ObservableCollection<CurrencyListItemViewModel>(tempCurrenciesList);
        }

        private bool CheckTimestamp()
        {
            var timeNow = DateTime.Now;
            DateTime lastUpdate = Preferences.Get(Constants.TIMESTAMP_KEY, new DateTime(0));
            TimeSpan delta = timeNow - lastUpdate;
            bool isMoreThen = delta.TotalHours > 24;
            return isMoreThen;
        }

        public void Tapped(Currency clickedCurrency)
        {
            ClickedCurrency = clickedCurrency;
            PopupNavigation.Instance.PushAsync(new MyPopupPage(this));
        }

        public void ReplaceCurrencyItem(Currency newCurrency)
        {
            ChoosenCurrencies.RemoveAt(newCurrency.Position);
            ChoosenCurrencies.Insert(newCurrency.Position, new CurrencyListItemViewModel(newCurrency));
        }

        public void EntryFocused(Entry sender, FocusEventArgs e)
        {
            if (focusedEntry == null)
            {
                focusedEntry = sender;
                focusedEntry.TextChanged += TextChangedHandler;
            }
            else if (focusedEntry == sender)
                return;
            else
            {
                focusedEntry.TextChanged -= TextChangedHandler;
                focusedEntry = sender;
                focusedEntry.TextChanged += TextChangedHandler;
            }
        }

        private void TextChangedHandler(object sender, TextChangedEventArgs args)
        {
            var ent = (Entry)sender;
            //(Currency) ent.BindingContext;
            double input = String.IsNullOrEmpty(args.NewTextValue) ? 0 : Convert.ToDouble(args.NewTextValue);
            ConvertCurrencyValues();
        }

        private void ConvertCurrencyValues()
        {

        }
    }
}
