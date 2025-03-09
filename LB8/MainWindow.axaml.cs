using System.Threading.Tasks;
using System;
using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;

namespace Lab3_2sem_3course;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Panel_PointerEnter(object sender, PointerEventArgs e)
    {
        if (sender is StackPanel panel)
        {
            var transformGroup = panel.RenderTransform as TransformGroup;
            var scaleX = transformGroup?.Children[0] as ScaleTransform;
            var scaleY = transformGroup?.Children[1] as ScaleTransform;
            var shadow = panel.Effect as DropShadowEffect;

            var animation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                Easing = new LinearEasing(),
                FillMode = FillMode.Forward,
                IterationCount = IterationCount.Parse("1"),
                Children =
                    {
                        new KeyFrame { Cue = new Cue(0), Setters = { new Setter(ScaleTransform.ScaleXProperty, scaleX?.ScaleX ?? 1) } },
                        new KeyFrame { Cue = new Cue(1), Setters = { new Setter(ScaleTransform.ScaleXProperty, 1.2) } }
                    }
            };

            var animation2 = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                Easing = new LinearEasing(),
                FillMode = FillMode.Forward,
                IterationCount = IterationCount.Parse("1"),
                Children =
                    {
                        new KeyFrame { Cue = new Cue(0), Setters = { new Setter(ScaleTransform.ScaleYProperty, scaleY?.ScaleY ?? 1) } },
                        new KeyFrame { Cue = new Cue(1), Setters = { new Setter(ScaleTransform.ScaleYProperty, 1.2) } }
                    }
            };

            var animation3 = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                Easing = new LinearEasing(),
                FillMode = FillMode.Forward,
                IterationCount = IterationCount.Parse("1"),
                Children =
                    {
                        new KeyFrame { Cue = new Cue(0), Setters = { new Setter(DropShadowEffect.OpacityProperty, shadow?.Opacity ?? 0) } },
                        new KeyFrame { Cue = new Cue(1), Setters = { new Setter(DropShadowEffect.OpacityProperty, 0.6) } }
                    }
            };

            await Task.WhenAll(
                animation.RunAsync(panel),
                animation2.RunAsync(panel),
                animation3.RunAsync(shadow)
            );

            if (panel.Children[0] is ImageWithArrowsUserControl control && control.Effect is BlurEffect blur)
            {
                var blurAnimation = new Animation
                {
                    Duration = TimeSpan.FromSeconds(1),
                    FillMode = FillMode.Forward,
                    IterationCount = IterationCount.Parse("1"),
                    Children =
                        {
                            new KeyFrame { Cue = new Cue(0), Setters = { new Setter(BlurEffect.RadiusProperty, blur.Radius) } },
                            new KeyFrame { Cue = new Cue(1), Setters = { new Setter(BlurEffect.RadiusProperty, 0) } }
                        }
                };

                await blurAnimation.RunAsync(blur);
            }
        }
    }

    private async void Panel_PointerLeave(object sender, PointerEventArgs e)
    {
        if (sender is StackPanel panel)
        {
            var transformGroup = panel.RenderTransform as TransformGroup;
            var scaleX = transformGroup?.Children[0] as ScaleTransform;
            var scaleY = transformGroup?.Children[1] as ScaleTransform;
            var shadow = panel.Effect as DropShadowEffect;

            var animation = new Animation
            {
                Duration = TimeSpan.FromSeconds(2),
                Easing = new LinearEasing(),
                IterationCount = IterationCount.Parse("1"),
                Children =
                    {
                        new KeyFrame { Cue = new Cue(0), Setters = { new Setter(ScaleTransform.ScaleXProperty, scaleX?.ScaleX ?? 1.2) } },
                        new KeyFrame { Cue = new Cue(1), Setters = { new Setter(ScaleTransform.ScaleXProperty, 1) } }
                    }
            };

            var animation2 = new Animation
            {
                Duration = TimeSpan.FromSeconds(2),
                Easing = new LinearEasing(),
                IterationCount = IterationCount.Parse("1"),
                Children =
                    {
                        new KeyFrame { Cue = new Cue(0), Setters = { new Setter(ScaleTransform.ScaleYProperty, scaleY?.ScaleY ?? 1.2) } },
                        new KeyFrame { Cue = new Cue(1), Setters = { new Setter(ScaleTransform.ScaleYProperty, 1) } }
                    }
            };

            var animation3 = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                Easing = new LinearEasing(),
                IterationCount = IterationCount.Parse("1"),
                Children =
                    {
                        new KeyFrame { Cue = new Cue(0), Setters = { new Setter(DropShadowEffect.OpacityProperty, shadow?.Opacity ?? 0.6) } },
                        new KeyFrame { Cue = new Cue(1), Setters = { new Setter(DropShadowEffect.OpacityProperty, 0) } }
                    }
            };

            await Task.WhenAll(
                animation.RunAsync(panel),
                animation2.RunAsync(panel),
                animation3.RunAsync(shadow)
            );

            if (panel.Children[0] is ImageWithArrowsUserControl control && control.Effect is BlurEffect blur)
            {
                var blurAnimation = new Animation
                {
                    Easing = new LinearEasing(),
                    
                    Duration = TimeSpan.FromSeconds(2),
                    IterationCount = IterationCount.Parse("1"),
                    Children =
                        {
                            new KeyFrame { Cue = new Cue(0), Setters = { new Setter(BlurEffect.RadiusProperty, blur.Radius) } },
                            new KeyFrame { Cue = new Cue(1), Setters = { new Setter(BlurEffect.RadiusProperty, 3) } }
                        }
          
                };

                await blurAnimation.RunAsync(blur);
            }
        }
    }
}

public static class AnimationUtils
{
    public static async Task AnimateDouble(
        this Animatable target,
        AvaloniaProperty property,
        double to,
        int duration
        )
    {
        var animation = new Animation
        {
            Duration = TimeSpan.FromMilliseconds(duration),
            Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(1d),
                        Setters = { new Setter(property, to) }
                    }
                }
        };

        await animation.RunAsync(target);
    }

}