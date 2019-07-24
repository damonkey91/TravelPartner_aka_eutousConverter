using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelPartner.ViewModel.Commands
{
    public class TappCommand : ICommand
    {
        private ITappedCallback tappedCallback;

        public TappCommand(ITappedCallback tappedCallback)
        {
            this.tappedCallback = tappedCallback;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            tappedCallback.Tapped();
        }
    }

    public interface ITappedCallback
    {
        void Tapped();
    }
}
