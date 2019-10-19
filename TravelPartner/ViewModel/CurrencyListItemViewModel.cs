using System;
using System.Collections.Generic;
using System.Text;
using TravelPartner.Model;

namespace TravelPartner.ViewModel
{
    public class CurrencyListItemViewModel : ViewModelBase
    {
        public Currency Currency { get; }
        public int Position { get => Currency.Position; set => Currency.Position = value; }
        public string Name
        {
            get => Currency.Name;  
        }
        public string ShortName { get => Currency.ShortName; }
        private string entryValue = "0";
        public string EntryValue { get => entryValue; set => SetProperty(ref entryValue, value); }
        public CurrencyListItemViewModel(Currency currency)
        {
            this.Currency = currency;
        }
    }
}
