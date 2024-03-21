using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Dem18_Svyatkin_Anton_409.Models;

namespace Dem18_Svyatkin_Anton_409;

public partial class ChooseRequestWindow : Window
{
    private User currentUser;
    public ChooseRequestWindow()
    {
        InitializeComponent();
    }
    
    public ChooseRequestWindow(User user)
    {
        MinHeight = 450;
        MaxHeight = 450;
        MinWidth = 800;
        MaxWidth = 800;
        
        InitializeComponent();

        currentUser = user;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void SingleRequest_OnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow(currentUser, 1);
    }

    private void GroupRequest_OnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow(currentUser, 2);
    }

    private void SingleEnterButton_OnClick(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow(currentUser, 1);
        requestWindow.Show();
        this.Close();
    }

    private void GroupEnterButton_OnClick(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow(currentUser, 2);
        requestWindow.Show();
        this.Close();
    }
}