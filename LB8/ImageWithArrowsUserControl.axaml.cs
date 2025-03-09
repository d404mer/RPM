using System;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using static System.Net.Mime.MediaTypeNames;

namespace Lab3_2sem_3course;

public partial class ImageWithArrowsUserControl : UserControl
{
    private int angle = 0;
    private RotateTransform _leftTransform = new RotateTransform(-90);
    private RotateTransform _rightTransform = new RotateTransform(90);

    public ImageWithArrowsUserControl()
    {
        InitializeComponent();
    }

    private void BtnLeft_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // Применяем поворот на -90 градусов
        natureImage.RenderTransformOrigin = RelativePoint.Center;
        angle -= 90;
        natureImage.RenderTransform = new RotateTransform() { Angle = angle };
    }

    private void BtnRight_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // Применяем поворот на +90 градусов
        natureImage.RenderTransformOrigin = RelativePoint.Center;
        angle += 90;
        natureImage.RenderTransform = new RotateTransform() { Angle = angle };
    }
}