using Avalonia.Controls;

namespace RPM_LABA7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PulsarOpen(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var secondWindow = new Pulsar();
            secondWindow.Show();
        }
        private void RunnerOpen(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var secondWindow = new Runner();
            secondWindow.Show();
        }
        private void CarouselOpen(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var secondWindow = new Carousel();
            secondWindow.Show();
        }
    }
}