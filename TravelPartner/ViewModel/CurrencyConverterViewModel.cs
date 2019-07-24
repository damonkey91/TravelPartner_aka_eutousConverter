using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TravelPartner.Helpers;
using TravelPartner.Model;
using TravelPartner.ViewModel.Commands;

namespace TravelPartner.ViewModel
{
    class CurrencyConverterViewModel : INotifyPropertyChanged, ITappedCallback
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

        public CurrencyConverterViewModel()
        {
            TappCommand = new TappCommand(this);
            PopulateObservableCollections();

            
            //if false update currency values if timestamp is more then 24 hours.
        }

        private async void PopulateObservableCollections()
        {
            List<Currency> currencies = await App.Database.ReadChoosen();
            ChoosenCurrencies = currencies != null ? new ObservableCollection<Currency>(currencies) : new ObservableCollection<Currency>();
            if (currencies.Count == 0)
                ChoosenCurrencies = new ObservableCollection<Currency>(await App.Database.Read(1, 11));            
        }

        private void OnPropertChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Tapped()
        {
            PopupNavigation.Instance.PushAsync(new MyPopupPage());
        }
    }
}
