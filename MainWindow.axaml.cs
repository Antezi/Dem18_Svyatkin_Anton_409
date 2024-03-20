using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Dem18_Svyatkin_Anton_409;

public partial class MainWindow : Window
{
    private TextBox _loginTextBox, _passwordTextBox, _loginRegTextBox, _passwordRegTextBox, _rePasswordRegTextBox;
    private Button _authButton, _regButton, _guestButton, _regAddButton, _backButton;
    private Border _logBorder, _regBorder;
    public MainWindow()
    {
        InitializeComponent();

        _loginTextBox = this.FindControl<TextBox>("LoginTextBox");
        _passwordTextBox = this.FindControl<TextBox>("PasswordTextBox");
        _loginRegTextBox = this.FindControl<TextBox>("LoginRegTextBox");
        _passwordRegTextBox = this.FindControl<TextBox>("PasswordRegTextBox");
        _rePasswordRegTextBox = this.FindControl<TextBox>("RePasswordRegTextBox");

        _authButton = this.FindControl<Button>("AuthButton");
        _regButton = this.FindControl<Button>("RegButton");
        _guestButton = this.FindControl<Button>("GuestButton");
        _regAddButton = this.FindControl<Button>("RegAddButton");
        _backButton = this.FindControl<Button>("BackButton");

        _logBorder = this.FindControl<Border>("LogBorder");
        _regBorder = this.FindControl<Border>("RegBorder");

    }

    private void AuthButton_OnClick(object? sender, RoutedEventArgs e)
    {

    }

    private void RegButton_OnClick(object? sender, RoutedEventArgs e)
    {
        _logBorder.IsVisible = false;
        _regBorder.IsVisible = true;
    }

    private void GuestButton_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void RegAddButton_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        _logBorder.IsVisible = true;
        _regBorder.IsVisible = false;
    }
    
    static string CalculateMD5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Преобразование байтов хеша в строку в формате hex
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    
}