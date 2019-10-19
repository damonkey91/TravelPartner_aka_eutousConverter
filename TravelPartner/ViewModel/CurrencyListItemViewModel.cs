using System;
using System.Collections.Generic;
using System.Text;
using TravelPartner.Model;

namespace TravelPartner.ViewModel
{
    public class CurrencyListItemViewModel : ViewModelBase
    {
        private Currency currency;
        public string Name
        {
            get => currency.Name;  
        }
        public string ShortName { get => currency.ShortName; }
        private string entryValue;
        public string EntryValue { get => entryValue; set => SetProperty(ref entryValue, value); }
        public CurrencyListItemViewModel(Currency currency)
        {
            this.currency = currency;
        }
    }
}
