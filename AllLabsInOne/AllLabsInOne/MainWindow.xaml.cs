using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllLabsInOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           this.Left = (SystemParameters.PrimaryScreenWidth - this.Width) / 2 - 650; 
           this.Top = (SystemParameters.PrimaryScreenHeight - this.Height) / 2;
        }

        private void Laba12_1_Click(object sender, RoutedEventArgs e)
        {
             LABA1_1 laba1_1 = new LABA1_1();
             laba1_1.Show();
        }

        private void Laba12_2_Click(object sender, RoutedEventArgs e)
        {
            LABA1_2 laba1_2 = new LABA1_2();
            laba1_2.Show();
        }

        private void Laba3_1_Click(object sender, RoutedEventArgs e)
        {
            LABA3_1 laba3_1 = new LABA3_1();
            laba3_1.Show();
        }

        private void Laba3_2_Click(object sender, RoutedEventArgs e)
        {
            LABA3_2 laba3_2 = new LABA3_2();
            laba3_2.Show();
        }

        private void Laba4_1_Click(object sender, RoutedEventArgs e)
        {
            LABA4_1 laba4_1 = new LABA4_1();
            laba4_1.Show();
        }

        private void Laba4_2_Click(object sender, RoutedEventArgs e)
        {
            LABA4_2 laba4_2 = new LABA4_2();
            laba4_2.Show();
        }

        private void Laba56_Click(object sender, RoutedEventArgs e)
        {
            LABA5 laba5 = new LABA5();
            laba5.Show();
        }

        private void Slider_Click(object sender, RoutedEventArgs e)
        {
            SLIDER slider = new SLIDER();
            slider.Show();
        }
    }
}