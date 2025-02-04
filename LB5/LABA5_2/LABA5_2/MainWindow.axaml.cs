using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using Avalonia.Controls.Shapes;

namespace LABA5_2
{
    public partial class MainWindow : Window
    {
        private bool isDrawing = false; // Флаг рисования
        private Point lastPoint; // Точка начала рисования
        private List<Line> lines = new List<Line>(); // Список всех линий, нарисованных на холсте
        private Brush currentColor = Brushes.Black as Brush; // Текущий цвет
        private double currentBrushSize = 2; // Текущая толщина кисти
        public MainWindow()
        {
            InitializeComponent();
        }
        // Обработчик начала рисования (когда нажата кнопка мыши)
        private void OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(drawCanvas).Properties.IsLeftButtonPressed)
            {
                isDrawing = true;
                lastPoint = e.GetPosition(drawCanvas); // Сохраняем начальную точку
            }
        }

        // Обработчик рисования (когда мышь перемещается)
        private void OnPointerMoved(object sender, PointerEventArgs e)
        {
            if (isDrawing)
            {
                var currentPoint = e.GetPosition(drawCanvas); // Получаем текущую точку
                DrawLine(lastPoint, currentPoint); // Рисуем линию
                lastPoint = currentPoint; // Обновляем начальную точку для следующего сегмента
            }
        }

        // Обработчик завершения рисования (когда кнопка мыши отпущена)
        private void OnPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false; // Завершаем рисование
            }
        }

        // Метод для рисования линии
        private void DrawLine(Point start, Point end)
        {
            var line = new Line
            {
                StartPoint = start,
                EndPoint = end,
                Stroke = currentColor, // Устанавливаем цвет линии
                StrokeThickness = currentBrushSize // Устанавливаем толщину линии
            };

            drawCanvas.Children.Add(line); // Добавляем линию на холст
            lines.Add(line); // Добавляем линию в список (для возможного использования в будущем)
        }

        // Методы для изменения цвета
        private void SetColorBlack(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentColor = Brushes.Black as Brush;
        }

        private void SetColorRed(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentColor = Brushes.Red as Brush;
        }

        private void SetColorGreen(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentColor = Brushes.Green as Brush;
        }

        // Метод для изменения толщины кисти
        private void brushSizeSlider_ValueChanged(object sender, Avalonia.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            currentBrushSize = e.NewValue;
        }
    }
}