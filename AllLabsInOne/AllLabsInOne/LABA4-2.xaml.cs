
using System.Windows;


namespace AllLabsInOne
{
    /// <summary>
    /// Interaction logic for LABA4_2.xaml
    /// </summary>
    public partial class LABA4_2 : Window
    {
        public double BrushSize { get; set; }
        public LABA4_2()
        {
            InitializeComponent();
            BrushSize = 10;
            DataContext = this;
        }
        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            inkCanvas.DefaultDrawingAttributes.Width = sizeSlider.Value;
            inkCanvas.DefaultDrawingAttributes.Height = sizeSlider.Value;
        }
    }
}
