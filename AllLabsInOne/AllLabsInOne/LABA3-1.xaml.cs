using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AllLabsInOne
{
    /// <summary>
    /// Interaction logic for LABA3_1.xaml
    /// </summary>
    public partial class LABA3_1 : Window
    {
        public LABA3_1()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateStatusBar("About dialog shown.");
            MessageBox.Show("Danilova A.A. 4237", "About", MessageBoxButton.OK);

        }

        private void MenuItem_Color_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            switch (item.Header.ToString())
            {
                case "_Yellow":
                    this.Background = System.Windows.Media.Brushes.Yellow;
                    break;
                case "_Green":
                    this.Background = System.Windows.Media.Brushes.LightGreen;
                    break;
                case "_Blue":
                    this.Background = System.Windows.Media.Brushes.LightBlue;
                    break;
            }
            UpdateStatusBar("Background color changed to " + item.Header);
        }

        private void ToolItem_About_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatusBar("About dialog shown.");
            MessageBox.Show("Danilova A.A. 4237", "About", MessageBoxButton.OK);

        }
        private void ToolItem_Color_Click(object sender, RoutedEventArgs e)
        {
            Button item = sender as Button;
            switch (item.Content.ToString())
            {
                case "Yellow":
                    this.Background = System.Windows.Media.Brushes.Yellow;
                    break;
                case "Green":
                    this.Background = System.Windows.Media.Brushes.LightGreen;
                    break;
                case "Blue":
                    this.Background = System.Windows.Media.Brushes.LightBlue;
                    break;
            }
            UpdateStatusBar("Background color changed to " + item.Content);
        }
        private void UpdateStatusBar(string text)
        {
            StatusBarText.Text = text;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
