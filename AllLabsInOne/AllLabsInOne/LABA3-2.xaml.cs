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
    /// Interaction logic for LABA3_2.xaml
    /// </summary>
    public partial class LABA3_2 : Window
    {

        public LABA3_2()

        {

            InitializeComponent();

            InitializeComboBox();

            InitializeSlider();

            InitializeRadioButtons();

            InitializeInkCanvas();

        }



        private void InitializeComboBox()

        {

            colorComboBox.SelectionChanged += ColorComboBox_SelectionChanged;

        }



        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {

            ComboBoxItem selectedItem = (ComboBoxItem)colorComboBox.SelectedItem;

            inkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(selectedItem.Tag.ToString());

        }



        private void InitializeSlider()

        {

            sizeSlider.ValueChanged += SizeSlider_ValueChanged;

        }



        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)

        {

            inkCanvas.DefaultDrawingAttributes.Height = inkCanvas.DefaultDrawingAttributes.Width = sizeSlider.Value;

        }



        private void InitializeRadioButtons()

        {

            drawRadioButton.Checked += ModeRadioButton_Checked;

            editRadioButton.Checked += ModeRadioButton_Checked;

            deleteRadioButton.Checked += ModeRadioButton_Checked;

        }



        private void ModeRadioButton_Checked(object sender, RoutedEventArgs e)

        {

            if (drawRadioButton.IsChecked == true)

            {

                inkCanvas.EditingMode = InkCanvasEditingMode.Ink;

            }

            else if (editRadioButton.IsChecked == true)

            {

                inkCanvas.EditingMode = InkCanvasEditingMode.Select;

            }

            else if (deleteRadioButton.IsChecked == true)

            {

                inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;

            }

            else if (deletemodelRadioButton.IsChecked == true)

            {

                inkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;

            }

        }

        private void InitializeInkCanvas()

        {

            inkCanvas.DefaultDrawingAttributes.Color = Colors.Black;

            inkCanvas.DefaultDrawingAttributes.Height = inkCanvas.DefaultDrawingAttributes.Width = 10;

            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;

        }



        private void deletemodelRadioButton_Checked(object sender, RoutedEventArgs e)

        {

            inkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;

        }

    }
}
