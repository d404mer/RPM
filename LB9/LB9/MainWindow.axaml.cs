using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Animation;

using Avalonia;
namespace LB9;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }


    private void SignClick(object sender, RoutedEventArgs e)
    {

        var animation = (Animation)this.Resources["ResourceAnimation"];

        animation.RunAsync((Button)sender);


    }
}