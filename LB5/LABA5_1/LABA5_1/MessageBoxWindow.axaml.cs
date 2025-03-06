using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LABA5_1;

public partial class MessageBoxWindow : Window
{
    public MessageBoxWindow()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void ShowMessage(string message)
    {
        var messageText = this.FindControl<TextBlock>("MessageText");
        messageText.Text = message;
    }

    private void OnOkClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

}