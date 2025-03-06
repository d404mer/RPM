using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPM_LABA7
{
    public partial class Carousel : Window
    {
        private bool isAnimating = false;
        private List<CarouselItem> carouselItems = new List<CarouselItem>();
        private CarouselItem? activeItem = null;
        private readonly double[] originalLeftPositions = { 100, 325, 550, 775, 1000 };
        private readonly double[] originalTopPositions = { 650, 670, 680, 670, 650 };

        public Carousel()
        {
            InitializeComponent();
            
            // Инициализация списка элементов
            for (int i = 1; i <= 5; i++)
            {
                var item = this.FindControl<CarouselItem>($"carouselItem{i}");
                if (item != null)
                {
                    int index = i - 1; // Сохраняем индекс для замыкания
                    item.PointerPressed += (s, e) => CarouselItem_PointerPressed(s, e, index);
                    carouselItems.Add(item);
                }
            }
        }

        private async void CarouselItem_PointerPressed(object? sender, PointerPressedEventArgs e, int itemIndex)
        {
            if (isAnimating || !(sender is CarouselItem clickedItem)) return;
            isAnimating = true;

            try
            {
                // Если есть активный элемент, возвращаем его на место
                if (activeItem != null)
                {
                    activeItem.Classes.Remove("active");
                    Canvas.SetLeft(activeItem, originalLeftPositions[carouselItems.IndexOf(activeItem)]);
                    Canvas.SetTop(activeItem, originalTopPositions[carouselItems.IndexOf(activeItem)]);
                }

                // Если кликнули по уже активному элементу, просто деактивируем его
                if (activeItem == clickedItem)
                {
                    activeItem = null;
                    return;
                }

                // Активируем новый элемент
                clickedItem.Classes.Add("active");
                
                // Вычисляем центральную позицию
                double centeredX = (Bounds.Width - clickedItem.Width) / 2;
                double centeredY = (Bounds.Height - clickedItem.Height) / 2;
                
                Canvas.SetLeft(clickedItem, centeredX);
                Canvas.SetTop(clickedItem, centeredY);

                activeItem = clickedItem;

                // Ждем 2.5 секунды если это не было снятием активного состояния
                await Task.Delay(2500);

                // Возвращаем на место только если элемент все еще активен
                if (activeItem == clickedItem)
                {
                    clickedItem.Classes.Remove("active");
                    Canvas.SetLeft(clickedItem, originalLeftPositions[itemIndex]);
                    Canvas.SetTop(clickedItem, originalTopPositions[itemIndex]);
                    activeItem = null;
                }
            }
            finally
            {
                isAnimating = false;
            }
        }
    }
}
