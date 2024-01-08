using System;
using ReactiveUI;
using System.Threading;
using AvaApp.ViewModels;

namespace Avalonia_Test.ViewModels
{
    internal class SplashWindowViewModel : ViewModelBase
    {
        private string _startUpMessage = "Application is Loading...";
        public string StartUpMessage
        {
            get { return _startUpMessage; }
            set
            {
                this.RaiseAndSetIfChanged(ref _startUpMessage, value);
            }
        }

        private CancellationTokenSource _cts = new CancellationTokenSource();
        public CancellationToken cancellationToken => _cts.Token;

        public void Cancel()
        {
            _cts.Cancel();
        }
    }
}
