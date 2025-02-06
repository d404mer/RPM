using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;
using Avalonia.Input;
using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;

namespace LABA5_2
{
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private List<Line> lines = new List<Line>();
        private Brush currentColor = new SolidColorBrush(Colors.Black); // Создаём новый экземпляр кисти
        private double currentBrushSize = 2;

        public MainWindow()
        {
            InitializeComponent();
            brushSizeSlider.ValueChanged += brushSizeSlider_ValueChanged;
        }

        private void OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(drawCanvas).Properties.IsLeftButtonPressed)
            {
                isDrawing = true;
                lastPoint = e.GetPosition(drawCanvas);
            }
        }

        private void OnPointerMoved(object sender, PointerEventArgs e)
        {
            if (isDrawing)
            {
                var currentPoint = e.GetPosition(drawCanvas);
                DrawLine(lastPoint, currentPoint);
                lastPoint = currentPoint;
            }
        }

        private void OnPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            isDrawing = false;
        }

        private void DrawLine(Point start, Point end)
        {
            var line = new Line
            {
                StartPoint = start,
                EndPoint = end,
                Stroke = currentColor, // Используем корректную кисть
                StrokeThickness = currentBrushSize
            };

            drawCanvas.Children.Add(line);
            ((ISetLogicalParent)line).SetParent(drawCanvas); // Нужно, чтобы элемент появился на Canvas

            lines.Add(line);
        }

        private void SetColorBlack(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentColor = new SolidColorBrush(Colors.Black);
        }

        private void SetColorRed(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentColor = new SolidColorBrush(Colors.Red);
        }

        private void SetColorBlue(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentColor = new SolidColorBrush(Colors.Blue);
        }

        private void brushSizeSlider_ValueChanged(object sender, Avalonia.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            currentBrushSize = e.NewValue;
        }
    }
}
