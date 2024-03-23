using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Dem18_Svyatkin_Anton_409.Context;
using Dem18_Svyatkin_Anton_409.Models;

namespace Dem18_Svyatkin_Anton_409;

public partial class ChooseRequestWindow : Window
{
    private ListBox _requestListBox;
    private List<RequestView> currentRequestList;
    private ComboBox _typeComboBox;
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

        _typeComboBox = this.FindControl<ComboBox>("TypeComboBox");
        _requestListBox = this.FindControl<ListBox>("RequestListBox");

        List<string> items = new List<string>();
        items.Add("Все");
        items.Add("Одиночные");
        items.Add("Групповые");
        
        RequestUpdate();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void RequestUpdate()
    {
        TradeContext context = new TradeContext();
        currentRequestList = context.Requests.Select(r => new RequestView()
        {
            Id = r.Id,
            Firstname = r.Firstname,
            Lastname = r.Lastname,
            Patronymic = r.Patronymic,
            Phone = r.Phone,
            Email = r.Email,
            Passport = r.Passport,
            Photo = r.Photo,
            Typeid = r.Typeid,
            Pass = r.Pass,
            Organisation = r.Organisation,
            Note = r.Note,
            Birthdate = r.Birthdate,
            Passportscan = r.Passportscan
        }).ToList();

        foreach (var r in currentRequestList)
        {
            try
            {
                Bitmap img = new Bitmap("../../../Assets/Images/" + r.Photo);
                r.PhotoView = img;
            }
            catch (Exception e)
            {

            }
            
            r.FirstnameView = "Имя: " + r.Firstname;
            r.LastnameView = "Фамилия: " + r.Lastname;
            r.PatronymicView = "Отчество: " + r.Patronymic;
            r.PhoneView = "Телефон: " + r.Phone;
            r.EmailView = "Email: " + r.Email;
            r.PassportView = "Паспорт: " + r.Passport;
            r.NoteView = "Примечание: " + r.Note;
            r.OrganisationView = "Организация: " + r.Organisation;
            r.BirthdateView = "Дата рождения: " + r.Birthdate;
            r.StartDateView = "Дата начала регистрации: " + r.Pass.Startdate;
            r.EndDateView = "Дата окончания регистрации: " + r.Pass.Enddate;
            r.PassportscanView = "Скан паспорта: " + r.Passportscan;

            if (r.Typeid == 1)
            {
                r.TypeView = "Тип посещения: Одиночное";
            }
            else
            {
                r.TypeView = "Тип посещения: Групповое";
            }
        }

        _requestListBox.Items = currentRequestList;
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