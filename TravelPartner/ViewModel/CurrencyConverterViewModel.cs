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

namespace TravelPartner.ViewModel
{
    public class CurrencyConverterViewModel : INotifyPropertyChanged, ITappedCallback
    {
        private ObservableCollection<Currency> choosenCurrencies;
        
        public ObservableCollection<Currency> ChoosenCurrencies
        {
            get => choosenCurrencies; set
            {
                choosenCurrencies = value;
                OnPropertChanged("ChoosenCurrencies");
            }
        }
        public TappCommand TappCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private Currency clickedCurrency;

        public Currency ClickedCurrency
        {
            get { return clickedCurrency; }
            private set { clickedCurrency = value; }
        }

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
                    ChoosenCurrencies = new ObservableCollection<Currency>(await Currency.InsertRateIntoCurrencies(ChoosenCurrencies, exchangeRate));
                    Preferences.Set(Constants.TIMESTAMP_KEY, DateTime.Now);                   
                }
            }
        }

        private async void PopulateObservableCollections()
        {
            List<Currency> currencies = await ChoosenCurrenciesTable.GetChoosenCurrencies(10);
            ChoosenCurrencies = currencies != null ? new ObservableCollection<Currency>(currencies) : new ObservableCollection<Currency>();
        }

        private bool CheckTimestamp()
        {
            var timeNow = DateTime.Now;
            DateTime lastUpdate = Preferences.Get(Constants.TIMESTAMP_KEY, new DateTime(0));
            TimeSpan delta = timeNow - lastUpdate;
            bool isMoreThen = delta.TotalHours > 24;
            return isMoreThen;
        }

        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Tapped(Currency clickedCurrency)
        {
            ClickedCurrency = clickedCurrency;
            PopupNavigation.Instance.PushAsync(new MyPopupPage(this));
        }

        public void ReplaceCurrencyItem(Currency newCurrency)
        {
            ChoosenCurrencies.RemoveAt(newCurrency.Position);
            ChoosenCurrencies.Insert(newCurrency.Position, newCurrency);
        }
    }
}
