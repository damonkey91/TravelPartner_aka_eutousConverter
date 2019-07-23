using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TravelPartner.Helpers;
using TravelPartner.Model;

namespace TravelPartner.ViewModel
{
    class CurrencyConverterViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Currency> choosenCurrencies;

        public ObservableCollection<Currency> Currencies
        {
            get => currencies; set
            {
                currencies = value;
                OnPropertChanged("Currencies");
            }
        }
        public ObservableCollection<Currency> ChoosenCurrencies
        {
            get => choosenCurrencies; set
            {
                choosenCurrencies = value;
                OnPropertChanged("ChoosenCurrencies");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public CurrencyConverterViewModel()
        {
            PopulateObservableCollections();

            //check if sql table is empty or >168
            //if true insert constant countries into sql database
            //if false update currency values if timestamp is more then 24 hours.
        }


        //Todo: Sql table with all currencies
        //Sql table with your choosen currencies

        private async void PopulateObservableCollections()
        {
            List<Currency> allCurrencies = await App.Database.ReadAll();
            List<Currency> currencies = await App.Database.ReadChoosen();
            if (allCurrencies == null || allCurrencies.Count < 168)
                App.Database.InsertAll(Constants.GetCountries());
            Currencies = allCurrencies != null ? new ObservableCollection<Currency>(allCurrencies) : new ObservableCollection<Currency>();
            ChoosenCurrencies = currencies != null ? new ObservableCollection<Currency>(currencies) : new ObservableCollection<Currency>();
        }

        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
