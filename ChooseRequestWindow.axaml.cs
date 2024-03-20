using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Dem18_Svyatkin_Anton_409;

public partial class ChooseRequestWindow : Window
{
    public ChooseRequestWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void SingleRequest_OnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        
    }

    private void GroupRequest_OnDoubleTapped(object? sender, RoutedEventArgs e)
    {

    }
}