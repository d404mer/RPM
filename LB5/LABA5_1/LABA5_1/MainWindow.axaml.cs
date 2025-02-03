using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using MsBox.Avalonia;
using System;

namespace LABA5_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        // Обработчик для кнопки "Exit"
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Обработчик для кнопки "About"
        private void AboutButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var messageBox = new MessageBoxWindow();
            messageBox.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterScreen;
            messageBox.Width = 200;
            messageBox.Height = 100;
            messageBox.ShowMessage("Данилова 4337");
            messageBox.ShowDialog(this);  
        }

        // Обработчик для кнопки "Red"
        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            this.Background = Avalonia.Media.Brushes.Red;
        }

        // Обработчик для кнопки "Yellow"
        private void YellowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Background = Avalonia.Media.Brushes.Yellow;
        }

    }
}