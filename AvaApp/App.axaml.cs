using AvaApp.ViewModels;
using AvaApp.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia_Test.ViewModels;
using System.Threading.Tasks;

namespace AvaApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var splashWindow = new SplashWindow();
                var splashWindowViewModel = new SplashWindowViewModel();

                splashWindow.DataContext = splashWindowViewModel;
                desktop.MainWindow = splashWindow;

                try
                {
                    splashWindowViewModel.StartUpMessage = "Application Loading...";
                    await Task.Delay(1000, cancellationToken: splashWindowViewModel.cancellationToken);

                    splashWindowViewModel.StartUpMessage = "Loading UI Elements...";
                    await Task.Delay(2000, cancellationToken: splashWindowViewModel.cancellationToken);

                    splashWindowViewModel.StartUpMessage = "Connecting to Server...";
                    await Task.Delay(1500, cancellationToken: splashWindowViewModel.cancellationToken);

                    splashWindowViewModel.StartUpMessage = "Hello Eddie...";
                    await Task.Delay(100, cancellationToken: splashWindowViewModel.cancellationToken);

                    splashWindowViewModel.StartUpMessage = "Making Connection with VLM...";
                    await Task.Delay(5000, cancellationToken: splashWindowViewModel.cancellationToken);

                    splashWindowViewModel.StartUpMessage = "Making Connection with Server...";
                    await Task.Delay(3500, cancellationToken: splashWindowViewModel.cancellationToken);

                    splashWindowViewModel.StartUpMessage = "Starting Application...";
                    await Task.Delay(7000, cancellationToken: splashWindowViewModel.cancellationToken);

                }
                catch (TaskCanceledException)
                {
                    splashWindow.Close();
                    return;
                }

                var mainWindow = new MainWindow();

                desktop.MainWindow = mainWindow;

                mainWindow.Show();

                splashWindow.Close();
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}
