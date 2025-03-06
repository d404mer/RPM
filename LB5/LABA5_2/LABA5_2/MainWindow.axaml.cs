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
        private bool isErasing = false;
        private bool isMovingLine = false; 
        private Point lastPoint;
        private List<Line> lines = new List<Line>();
        private List<Line> selectedLines = new List<Line>(); 
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
                    DeselectLines();
                    SelectLinesAtPoint(lastPoint); 
                    if (selectedLines.Count > 0)  
                    {
                        isMovingLine = true;
                    }
                    SelectLinesAtPoint(lastPoint);
                }
                else if (currentMode == "Erase")
                {
                    isErasing = true;
                    EraseLineAtPoint(lastPoint);
                }
            }
        }

        private void OnPointerMoved(object sender, PointerEventArgs e)
        {
            var currentPoint = e.GetPosition(drawCanvas);

            if (isDrawing && currentMode == "Draw")
            {
                DrawLine(lastPoint, currentPoint);
                lastPoint = currentPoint;
            }
            else if (isMovingLine && currentMode == "Edit" && selectedLines.Count > 0)
            {
                MoveSelectedLines(currentPoint);  
            }
            else if (currentMode == "Erase")
            {
                EraseLineAtPoint(currentPoint);
            }
        }

        private void OnPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            isDrawing = false;
            isErasing = false;
            isMovingLine = false; 
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
                if (Math.Abs(line.StartPoint.X - point.X) < currentBrushSize && Math.Abs(line.StartPoint.Y - point.Y) < currentBrushSize)
                {
                    drawCanvas.Children.Remove(line);
                    lines.Remove(line);
                    break;
                }
            }
        }

        private void SelectLinesAtPoint(Point point)
        {
            selectedLines.Clear();  

            double selectionThreshold = 500;

           
            foreach (var line in lines)
            {
            
                if (Math.Abs(line.StartPoint.X - point.X) < selectionThreshold && Math.Abs(line.StartPoint.Y - point.Y) < selectionThreshold ||
                    Math.Abs(line.EndPoint.X - point.X) < selectionThreshold && Math.Abs(line.EndPoint.Y - point.Y) < selectionThreshold)
                {
                    if (line.Stroke.Equals(currentColor))  
                    {
                        selectedLines.Add(line);
                        //line.Stroke = new SolidColorBrush(Colors.Green);  // Выделяем линию
                        line.StrokeThickness = currentBrushSize + 2;  
                    }
                }
            }
        }

        private void DeselectLines()
        {
            
            foreach (var line in selectedLines)
            {
                
                //line.Stroke = new SolidColorBrush(currentColor); 
                line.StrokeThickness = currentBrushSize;  
            }

            selectedLines.Clear();
        }




        private void MoveSelectedLines(Point newPoint)
        {
            if (selectedLines.Count > 0)
            {
                var deltaX = newPoint.X - lastPoint.X;
                var deltaY = newPoint.Y - lastPoint.Y;

                foreach (var line in selectedLines)
                {
                    line.StartPoint = new Point(line.StartPoint.X + deltaX, line.StartPoint.Y + deltaY);
                    line.EndPoint = new Point(line.EndPoint.X + deltaX, line.EndPoint.Y + deltaY);
                }
            }

            lastPoint = newPoint;
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
