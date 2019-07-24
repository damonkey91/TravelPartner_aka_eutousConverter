using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TravelPartner.Helpers;
using TravelPartner.Model;
using Xamarin.Forms;

namespace TravelPartner.ViewModel
{
    class PopupViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Currency> currencies;
        private string searchText;

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


        public PopupViewModel()
        {
            PopulateObservableCollections();
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
    }
}
