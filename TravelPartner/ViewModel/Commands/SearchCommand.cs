using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelPartner.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ISearchBarCallback callback;

        public SearchCommand(ISearchBarCallback callback)
        {
            this.callback = callback;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string inputText = parameter as string;
            callback.Search(inputText);
        }
    }

    public interface ISearchBarCallback
    {
        void Search(string input);
    }
}
