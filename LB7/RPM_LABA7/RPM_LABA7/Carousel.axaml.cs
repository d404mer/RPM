using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using System;
using Avalonia.Interactivity;

namespace RPM_LABA7;

public partial class Carousel : Window
{
    public Carousel()
    {
        InitializeComponent();
        // Подписываемся на нажатие
        img1.PointerPressed += OnImageTapped;
        img2.PointerPressed += OnImageTapped;
    }
    private async void OnImageTapped(object? sender, PointerPressedEventArgs e)
    {
    
        if (sender is Image image)
        {
            // Запускаем анимацию из ресурсов
            if (this.Resources.TryGetResource("ImageAnimation", null, out var anim) && anim is Animation animation)
            {
                await animation.RunAsync(image);
            }
        }
    }
}
