using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Dem18_Svyatkin_Anton_409.Context;
using Dem18_Svyatkin_Anton_409.Models;
using Npgsql.Internal.TypeHandlers;

namespace Dem18_Svyatkin_Anton_409;

public partial class MainWindow : Window
{
    private User currentUser;
    private List<User> testList;
    private TextBox _loginTextBox, _passwordTextBox, _loginRegTextBox, _passwordRegTextBox, _rePasswordRegTextBox;
    private Button _authButton, _regButton, _guestButton, _regAddButton, _backButton;
    private Border _logBorder, _regBorder;
    public MainWindow()
    {
        MinHeight = 400;
        MaxHeight = 400;
        MinWidth = 600;
        MaxWidth = 600;

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
        /*TradeContext _context = new TradeContext();

        testList = _context.Users.Select(u => new User()
        {
            Id = u.Id,
            Login = u.Login,
            Password = u.Password
        }).ToList();*/
        
        if (_loginTextBox != null && _loginTextBox.Text != "" && _passwordTextBox != null && _passwordTextBox.Text != "")
        {
            TradeContext context = new TradeContext();
            currentUser = context.Users.Where(u => u.Login == _loginTextBox.Text && u.Password == CalculateMD5Hash(_passwordTextBox.Text)).FirstOrDefault();
            if (currentUser != null)
            {
                ChooseRequestWindow chooseRequestWindow = new ChooseRequestWindow(currentUser);
                chooseRequestWindow.Show();
                this.Close();
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Неправильный логин/пароль");
                messageWindow.Show();
            }
        }
        else
        {
            MessageWindow messageWindow = new MessageWindow("Одно из полей является пустым");
            messageWindow.Show();
        }
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
        if (_loginRegTextBox != null && _loginRegTextBox.Text != "" && _passwordRegTextBox != null &&
            _passwordRegTextBox.Text != "" && _rePasswordRegTextBox != null && _rePasswordRegTextBox.Text != "")

        {
            if (_passwordRegTextBox.Text == _rePasswordRegTextBox.Text)
            {
                TradeContext context = new TradeContext();
                currentUser = new User()
                {
                    Login = _loginRegTextBox.Text,
                    Password = CalculateMD5Hash(_passwordRegTextBox.Text),
                    RoleCode = 3
                };
                try
                {
                    context.Users.Add(currentUser);
                    context.SaveChanges();
                    MessageWindow messageWindow = new MessageWindow("Вы успешно зарегистировались");
                    messageWindow.Show();

                    currentUser = context.Users.Where(u => u.Login == _loginRegTextBox.Text && u.Password == CalculateMD5Hash(_passwordRegTextBox.Text)).FirstOrDefault();
                    ChooseRequestWindow chooseRequestWindow = new ChooseRequestWindow(currentUser);
                    chooseRequestWindow.Show();
                    this.Close();
                }
                catch (Exception exception)
                {
                    MessageWindow messageWindow = new MessageWindow("Возникли ошибки при попытке регистрации");
                    messageWindow.Show();
                }
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Пароли должны повторяться");
                messageWindow.Show();
            }
        }
        else
        {
            MessageWindow messageWindow = new MessageWindow("Одно из полей является пустым");
            messageWindow.Show();
        }
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