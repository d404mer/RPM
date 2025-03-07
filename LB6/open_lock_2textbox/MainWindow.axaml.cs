using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace open_lock_2textbox
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CleanClick(object? sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        private void CloseClick(object? sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                open.IsChecked = true;
                close.IsEnabled = false;
            }
        }




    }
}
