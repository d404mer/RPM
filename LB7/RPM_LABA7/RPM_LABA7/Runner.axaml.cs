using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using System;

namespace RPM_LABA7;

public partial class Runner : Window
{
    private Random random = new Random();

    public Runner()
    {
        InitializeComponent();
        runAwayButton.AddHandler(Button.PointerEnteredEvent, btn_PointerEnter, handledEventsToo: true);
    }

    private void btn_PointerEnter(object sender, PointerEventArgs e)
    {
        var button = (Button)sender;
        double buttonWidth = button.Width;
        double buttonHeight = button.Height;
        double currentPosX = Canvas.GetLeft(button);
        double currentPosY = Canvas.GetTop(button);
        double canvasWidth = MainCanvas.Bounds.Width;
        double canvasHeight = MainCanvas.Bounds.Height;

        var random = new Random();
        double offsetX = random.Next(-50, 51);
        double offsetY = random.Next(-50, 51);

        double newPosX = currentPosX + offsetX;
        double newPosY = currentPosY + offsetY;

        if (newPosX < 0) newPosX = 0;
        else if (newPosX + buttonWidth > canvasWidth) newPosX = canvasWidth - buttonWidth;

        if (newPosY < 0) newPosY = 0;
        else if (newPosY + buttonHeight > canvasHeight) newPosY = canvasHeight - buttonHeight;

        Canvas.SetLeft(button, newPosX);
        Canvas.SetTop(button, newPosY);
    }



}