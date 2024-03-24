using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Castle.Components.DictionaryAdapter;
using Dem18_Svyatkin_Anton_409.Context;
using Dem18_Svyatkin_Anton_409.Models;

namespace Dem18_Svyatkin_Anton_409;

public partial class ChooseRequestWindow : Window
{
    private ListBox _requestListBox, _groupListBox;
    private List<Groupuser> _currenGroupList = new List<Groupuser>();
    private List<RequestView> currentRequestList = new List<RequestView>();
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
        _groupListBox = this.FindControl<ListBox>("GroupListBox");

        List<string> items = new List<string>();
        items.Add("Одиночные");
        items.Add("Групповые");
        _typeComboBox.Items = items;
        
        SingleRequestUpdate();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void SingleRequestUpdate()
    {
        TradeContext context = new TradeContext();
        currentRequestList = context.Requests.Where(r => r.User.Id == currentUser.Id).Select(r => new RequestView()
        {
            Id = r.Id,
            Firstname = r.User.Firstname,
            Lastname = r.User.Lastname,
            Patronymic = r.User.Patronymic,
            Phone = r.User.Phone,
            Email = r.User.Email,
            Passport = r.User.Passport,
            Photo = r.User.Photo,
            Typeid = r.Typeid,
            Pass = r.Pass,
            Organisation = r.Organisation,
            Note = r.Note,
            Birthdate = r.User.Birthdate,
            Passportscan = r.User.Passportscan,
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

    public void GroupRequestUpdate()
    {
        TradeContext context = new TradeContext();
        currentRequestList = context.Requests.Where(r => r.User.Id == currentUser.Id).Select(r => new RequestView()
        {
            Id = r.Id,
            Firstname = r.User.Firstname,
            Lastname = r.User.Lastname,
            Patronymic = r.User.Patronymic,
            Phone = r.User.Phone,
            Email = r.User.Email,
            Passport = r.User.Passport,
            Photo = r.User.Photo,
            Typeid = r.Typeid,
            Pass = r.Pass,
            Organisation = r.Organisation,
            Note = r.Note,
            Birthdate = r.User.Birthdate,
            Passportscan = r.User.Passportscan,
            Groupusers = r.Groupusers,
            GroupusersNavigation = r.GroupusersNavigation
            
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
            



           for (int i = 0; i < r.GroupusersNavigation.Firstname.Length; i++)
            {
                Groupuser currentGroupUser = new Groupuser
                {
                    Firstname = r.GroupusersNavigation.Firstname,
                    Lastname = r.GroupusersNavigation.Lastname,
                    Patronymic = r.GroupusersNavigation.Patronymic,
                    Email = r.GroupusersNavigation.Email,
                    Phone = r.GroupusersNavigation.Phone,
                    Passport = r.GroupusersNavigation.Passport
                };
                _currenGroupList.Add(currentGroupUser);
            }
           _groupListBox.Items = _currenGroupList;
        }
        _requestListBox.Items = currentRequestList;
    }

    private void SingleRequest_OnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow(currentUser, 1);
        requestWindow.Show();
        this.Close();
    }

    private void GroupRequest_OnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        RequestWindow requestWindow = new RequestWindow(currentUser, 2);
        requestWindow.Show();
        this.Close();
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

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void TypeComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_typeComboBox.SelectedIndex == 0)
        {
            SingleRequestUpdate();
        }
        else if (_typeComboBox.SelectedIndex == 1)
        {
            GroupRequestUpdate();
        }
    }
}