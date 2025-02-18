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

        // Объявляем анимируемые свойства
        public static readonly StyledProperty<double> ImageScaleXProperty =
            AvaloniaProperty.Register<Carousel, double>(nameof(ImageScaleX), 1.0);
        public static readonly StyledProperty<double> ImageScaleYProperty =
            AvaloniaProperty.Register<Carousel, double>(nameof(ImageScaleY), 1.0);
        public static readonly StyledProperty<double> ImageSkewAngleYProperty =
            AvaloniaProperty.Register<Carousel, double>(nameof(ImageSkewAngleY), 22.0);

        public double ImageScaleX
        {
            get => GetValue(ImageScaleXProperty);
            set => SetValue(ImageScaleXProperty, value);
        }

        public double ImageScaleY
        {
            get => GetValue(ImageScaleYProperty);
            set => SetValue(ImageScaleYProperty, value);
        }

        public double ImageSkewAngleY
        {
            get => GetValue(ImageSkewAngleYProperty);
            set => SetValue(ImageSkewAngleYProperty, value);
        }

        public Carousel()
        {
            InitializeComponent();
            DataContext = this;

            // Присваиваем imageControl
            imageControl = this.FindControl<Image>("image");

            // Подписываемся на событие PointerPressed
            if (imageControl != null)
            {
                imageControl.PointerPressed += Image_PointerPressed;
            }
        }

        private async void Image_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (isAnimating) return;  // Предотвращаем повторный вызов
            var secondWindow = new Runner();
            secondWindow.Show();
            isAnimating = true;

            if (imageControl == null)
            {
                return;
            }

            // Анимация для ImageScaleX
            var scaleXAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(ImageScaleXProperty, 1.0) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(ImageScaleXProperty, 2.25) }
                    }
                }
            };

            // Анимация для ImageScaleY
            var scaleYAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(ImageScaleYProperty, 1.0) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(ImageScaleYProperty, 2.25) }
                    }
                }
            };

            // Анимация для ImageSkewAngleY
            var skewAnimation = new Animation
            {
                Duration = TimeSpan.FromSeconds(1),
                FillMode = FillMode.Forward,
                Children =
                {
                    new KeyFrame
                    {
                        Cue = new Cue(0),
                        Setters = { new Setter(ImageSkewAngleYProperty, 22.0) }
                    },
                    new KeyFrame
                    {
                        Cue = new Cue(1),
                        Setters = { new Setter(ImageSkewAngleYProperty, 0.0) }
                    }
                }
            };

            // Запускаем анимации на imageControl, а не на Window
            await scaleXAnimation.RunAsync(imageControl, CancellationToken.None);
            await scaleYAnimation.RunAsync(imageControl, CancellationToken.None);
            await skewAnimation.RunAsync(imageControl, CancellationToken.None);

            isAnimating = false; // Сбрасываем флаг после завершения анимации
        }
    }
}
