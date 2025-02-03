using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using System.Reactive;


namespace LABA5_RPM
{
    public class MainViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> ExitCommand { get; }
        public ReactiveCommand<Unit, Unit> AboutCommand { get; }
        public ReactiveCommand<string, Unit> ChangeColorCommand { get; }

        public MainViewModel()
        {
            ExitCommand = ReactiveCommand.Create(() => CloseApp());
            AboutCommand = ReactiveCommand.Create(() => ShowAbout());
            ChangeColorCommand = ReactiveCommand.Create<string>(color => ChangeBackground(color));
        }

        private void CloseApp()
        {
            var app = Application.Current?.ApplicationLifetime as Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime;
            app?.MainWindow?.Close();
        }

        private void ShowAbout()
        {
            MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("About", "Danilova A.A. 4337")
                .Show();
        }

        private void ChangeBackground(string color)
        {
            var mainWindow = Application.Current?.ApplicationLifetime as Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime;
            if (mainWindow?.MainWindow != null)
            {
                mainWindow.MainWindow.Background = color switch
                {
                    "Red" => Avalonia.Media.Brushes.Red,
                    "Yellow" => Avalonia.Media.Brushes.Yellow,
                    _ => mainWindow.MainWindow.Background
                };
            }
        }
    }
}
