using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Dem18_Svyatkin_Anton_409;

public partial class MessageWindow : Window
{
    private TextBlock _messageTextBlock;
    public MessageWindow()
    {
        InitializeComponent();
    }
    
    public MessageWindow(string message)
    {
        InitializeComponent();

        _messageTextBlock = this.FindControl<TextBlock>("MessageTextBlock");

        _messageTextBlock.Text = message;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OkButton_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}