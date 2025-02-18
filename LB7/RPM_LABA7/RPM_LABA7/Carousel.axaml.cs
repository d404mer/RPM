using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RPM_LABA7
{
    public partial class Carousel : Window
    {
        private bool isAnimating = false; // Флаг для предотвращения двойного вызова
        private Image? imageControl;  // Переименовали в imageControl

        public Carousel()
        {
            InitializeComponent();
            DataContext = this;

            // Присваиваем imageControl
            imageControl = this.FindControl<Image>("image");

            if (imageControl != null)
            {
                imageControl.PointerPressed += Image_PointerPressed;
            }
        }

        private async void Image_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (isAnimating) return;  // Предотвращаем повторный вызов
            isAnimating = true;

            if (imageControl == null)
            {
                return;
            }

            // Создаем трансформацию и привязываем её к RenderTransform
            var transformGroup = new TransformGroup();
            var scaleTransform = new ScaleTransform();
            var skewTransform = new SkewTransform();

            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(skewTransform);
            imageControl.RenderTransform = transformGroup;

            // Анимация для ScaleX
            var scaleXAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(ScaleTransform.ScaleXProperty, 1.0) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(ScaleTransform.ScaleXProperty, 2.25) }
                    }
                }
            };

            // Анимация для ScaleY
            var scaleYAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(ScaleTransform.ScaleYProperty, 1.0) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(ScaleTransform.ScaleYProperty, 2.25) }
                    }
                }
            };

            // Анимация для SkewAngleY
            var skewAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(SkewTransform.AngleYProperty, 22.0) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(SkewTransform.AngleYProperty, 0.0) }
                    }
                }
            };

            // Запускаем анимации на imageControl
            await scaleXAnimation.RunAsync(imageControl, CancellationToken.None);
            await scaleYAnimation.RunAsync(imageControl, CancellationToken.None);
            await skewAnimation.RunAsync(imageControl, CancellationToken.None);

            // Добавляем анимации для возврата в начальное состояние
            var reverseScaleXAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(ScaleTransform.ScaleXProperty, 2.25) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(ScaleTransform.ScaleXProperty, 1.0) }
                    }
                }
            };

            var reverseScaleYAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(ScaleTransform.ScaleYProperty, 2.25) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(ScaleTransform.ScaleYProperty, 1.0) }
                    }
                }
            };

            var reverseSkewAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(SkewTransform.AngleYProperty, 0.0) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(SkewTransform.AngleYProperty, 22.0) }
                    }
                }
            };

            // Запускаем анимации для возврата в начальное положение
            await reverseScaleXAnimation.RunAsync(imageControl, CancellationToken.None);
            await reverseScaleYAnimation.RunAsync(imageControl, CancellationToken.None);
            await reverseSkewAnimation.RunAsync(imageControl, CancellationToken.None);

            isAnimating = false; // Сбрасываем флаг после завершения анимации
        }
    }
}
