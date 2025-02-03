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
    /// Interaction logic for LABA4_1.xaml
    /// </summary>
    public partial class LABA4_1 : Window
    {
        public LABA4_1()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Danilova A.A. 4237");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Danilova A.A. 4237");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Background = System.Windows.Media.Brushes.Red;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Background = System.Windows.Media.Brushes.Yellow;
        }
    }
}
