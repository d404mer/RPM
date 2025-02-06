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
        private Brush currentColor = new SolidColorBrush(Colors.Black); 
        private double currentBrushSize = 2;
        private string currentMode = "Draw";

        public MainWindow()
        {
            InitializeComponent();
            brushSizeSlider.ValueChanged += brushSizeSlider_ValueChanged;
        }

        private void OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(drawCanvas).Properties.IsLeftButtonPressed)
            {
                lastPoint = e.GetPosition(drawCanvas);

                if (currentMode == "Draw")
                {
                    isDrawing = true;
                }
                else if (currentMode == "Edit")
                {
                    // Start editing: Select a line to move
                    SelectLineAtPoint(lastPoint);
                }
                else if (currentMode == "Erase")
                {
                    // Start erasing: Erase a line
                    EraseLineAtPoint(lastPoint);
                }
            }
        }

        private void OnPointerMoved(object sender, PointerEventArgs e)
        {
            if (isDrawing && currentMode == "Draw")
            {
                var currentPoint = e.GetPosition(drawCanvas);
                DrawLine(lastPoint, currentPoint);
                lastPoint = currentPoint;
            }
            else if (currentMode == "Edit")
            {
                // Move selected line (if any)
                MoveSelectedLine(e.GetPosition(drawCanvas));
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
                Stroke = currentColor, 
                StrokeThickness = currentBrushSize
            };

            drawCanvas.Children.Add(line);
            ((ISetLogicalParent)line).SetParent(drawCanvas); 

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

        private void EraseLineAtPoint(Point point)
        {
            foreach (var line in lines)
            {
                if (Math.Abs(line.StartPoint.X - point.X) < 10 && Math.Abs(line.StartPoint.Y - point.Y) < 10)
                {
                    drawCanvas.Children.Remove(line);
                    lines.Remove(line);
                    break;
                }
            }
        }

        private void SelectLineAtPoint(Point point)
        {
            foreach (var line in lines)
            {
                if (Math.Abs(line.StartPoint.X - point.X) < 10 && Math.Abs(line.StartPoint.Y - point.Y) < 10)
                {
                    line.Stroke = new SolidColorBrush(Colors.Green);  // Highlight the selected line
                    break;
                }
            }
        }

        private void MoveSelectedLine(Point newPoint)
        {
           
            foreach (var line in lines)
            {
                if (line.Stroke == new SolidColorBrush(Colors.Red))
                {
                    var deltaX = newPoint.X - line.StartPoint.X;
                    var deltaY = newPoint.Y - line.StartPoint.Y;

                    line.StartPoint = new Point(line.StartPoint.X + deltaX, line.StartPoint.Y + deltaY);
                    line.EndPoint = new Point(line.EndPoint.X + deltaX, line.EndPoint.Y + deltaY);
                    break;
                }
            }
        }

         private void OnModeButtonClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
 
            if (sender == drawButton)
            {
                currentMode = "Draw";
            }
            else if (sender == editButton)
            {
                currentMode = "Edit";
            }
            else if (sender == eraseButton)
            {
                currentMode = "Erase";
            }
        }
    }
}
