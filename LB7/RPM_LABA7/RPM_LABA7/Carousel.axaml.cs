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
        private ScaleTransform scaleTransform;
        private SkewTransform skewTransform;

        // Объявляем анимируемые свойства
        public static readonly StyledProperty<double> ImageScaleXProperty =
            AvaloniaProperty.Register<Carousel, double>(nameof(ImageScaleX));
        public static readonly StyledProperty<double> ImageScaleYProperty =
            AvaloniaProperty.Register<Carousel, double>(nameof(ImageScaleY));
        public static readonly StyledProperty<double> ImageSkewAngleYProperty =
            AvaloniaProperty.Register<Carousel, double>(nameof(ImageSkewAngleY));

        public double ImageScaleX
        {
            get => GetValue(ImageScaleXProperty);
            set
            {
                SetValue(ImageScaleXProperty, value);
                if (scaleTransform != null)
                    scaleTransform.ScaleX = value;
            }
        }

        public double ImageScaleY
        {
            get => GetValue(ImageScaleYProperty);
            set
            {
                SetValue(ImageScaleYProperty, value);
                if (scaleTransform != null)
                    scaleTransform.ScaleY = value;
            }
        }

        public double ImageSkewAngleY
        {
            get => GetValue(ImageSkewAngleYProperty);
            set
            {
                SetValue(ImageSkewAngleYProperty, value);
                if (skewTransform != null)
                    skewTransform.AngleY = value;
            }
        }

        public Carousel()
        {
            InitializeComponent();
            var image = this.FindControl<Image>("image");

            // Получаем ScaleTransform и SkewTransform из RenderTransform
            if (image.RenderTransform is TransformGroup transformGroup)
            {
                scaleTransform = transformGroup.Children[0] as ScaleTransform;
                skewTransform = transformGroup.Children[1] as SkewTransform;
            }

            // Инициализируем свойства начальными значениями
            ImageScaleX = 1.0;
            ImageScaleY = 1.0;
            ImageSkewAngleY = 22.0;

            // Подписываемся на событие PointerPressed
            image.PointerPressed += Image_PointerPressed;
        }

        private async void Image_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (scaleTransform == null || skewTransform == null)
            {
                Console.WriteLine("ScaleTransform или SkewTransform не найдены!");
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

            // Запускаем анимации на this (окно наследует Visual)
            await scaleXAnimation.RunAsync(this, CancellationToken.None);
            await scaleYAnimation.RunAsync(this, CancellationToken.None);
            await skewAnimation.RunAsync(this, CancellationToken.None);
        }
    }
}
