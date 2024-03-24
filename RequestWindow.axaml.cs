using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Dem18_Svyatkin_Anton_409.Context;
using Dem18_Svyatkin_Anton_409.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dem18_Svyatkin_Anton_409;

public partial class RequestWindow : Window
{
    private Grid _singleGrid,_groupGrid; 
    private Request currentRequest = new Request();
    private Divisionrequest currentDivisionRequest = new Divisionrequest();
    private Pass currentPass = new Pass();
    private List<UserView> usersList = new List<UserView>() ;
    private List<Purpose> purposesLists;
    private User currentUser, updateUser;
    private Groupuser currentGroupUser = new Groupuser();
    private string imgName, fileImgName, PDFName, filePDFName;
    private int _requestType;
    private ComboBox _purposeComboBox, _divisionComboBox, _fIOComboBox;
    private Image _personImage; 
    private CalendarDatePicker  _startDateCalendarPicker, _endDateCalendarPicker, _birthdateCalendarPicker, _grBirthdateCalendarPicker;
    private MaskedTextBox _phoneMaskedTextBox, _grPhoneMaskedTextBox, _serialMaskedTextBox, _numberMaskedTextBox,  _grSerialMaskedTextBox, _grNumberMaskedTextBox;
    private TextBlock _uploadedFileTextBlock;
    private ListBox _groupUsersListBox;

    private TextBox _passFIOTextBox,
        _lastNameTextBox,
        _firstNameTextBox,
        _patronymicTextBox,
        _emailTextBox,
        _organizationTextBox,
        _noteTextBox,
        _grLastNameTextBox,
        _grFirstNameTextBox,
        _grPatronymicTextBox,
        _grEmailTextBox,
        _grOrganizationTextBox,
        _grNoteTextBox;
    public RequestWindow()
    {
        MinHeight = 700;
        MaxHeight = 700;
        MinWidth = 900;
        MaxWidth = 900;
        
        InitializeComponent();
    }
    
    public RequestWindow(User user, int requestType)
    {
        MinHeight = 700;
        MaxHeight = 700;
        MinWidth = 900;
        MaxWidth = 900;
        
        InitializeComponent();

        _passFIOTextBox = this.FindControl<TextBox>("PassFIOTextBox");
        _lastNameTextBox = this.FindControl<TextBox>("LastNameTextBox");
        _firstNameTextBox = this.FindControl<TextBox>("FirstNameTextBox");
        _patronymicTextBox = this.FindControl<TextBox>("PatronymicTextBox");
        _emailTextBox = this.FindControl<TextBox>("EmailTextBox");
        _organizationTextBox = this.FindControl<TextBox>("OrganizationTextBox");
        _noteTextBox = this.FindControl<TextBox>("NoteTextBox");
        _grLastNameTextBox = this.FindControl<TextBox>("GrLastNameTextBox");
        _grFirstNameTextBox = this.FindControl<TextBox>("GrFirstNameTextBox");
        _grPatronymicTextBox = this.FindControl<TextBox>("GrPatronymicTextBox");
        _grEmailTextBox = this.FindControl<TextBox>("GrEmailTextBox");
        _grOrganizationTextBox = this.FindControl<TextBox>("GrOrganizationTextBox");
        _grNoteTextBox = this.FindControl<TextBox>("GrNoteTextBox");

        _uploadedFileTextBlock = this.FindControl<TextBlock>("UploadedFileTextBlock");

        _phoneMaskedTextBox = this.FindControl<MaskedTextBox>("PhoneMaskedTextBox");
        _grPhoneMaskedTextBox = this.FindControl<MaskedTextBox>("GrPhoneMaskedTextBox");
        _serialMaskedTextBox = this.FindControl<MaskedTextBox>("SerialMaskedTextBox");
        _numberMaskedTextBox = this.FindControl<MaskedTextBox>("NumberMaskedTextBox");
        _grSerialMaskedTextBox = this.FindControl<MaskedTextBox>("GrSerialMaskedTextBox");
        _grNumberMaskedTextBox = this.FindControl<MaskedTextBox>("GrNumberMaskedTextBox");
        

        _purposeComboBox = this.FindControl<ComboBox>("PurposeComboBox");
        _divisionComboBox = this.FindControl<ComboBox>("DivisionComboBox");
        _fIOComboBox = this.FindControl<ComboBox>("FIOComboBox");

        _startDateCalendarPicker = this.FindControl<CalendarDatePicker>("StartDateCalendarPicker");
        _endDateCalendarPicker = this.FindControl<CalendarDatePicker>("EndDateCalendarPicker");
        _birthdateCalendarPicker = this.FindControl<CalendarDatePicker>("BirthdateCalendarPicker");
        _grBirthdateCalendarPicker = this.FindControl<CalendarDatePicker>("GrBirthdateCalendarPicker");
        

        _groupUsersListBox = this.FindControl<ListBox>("GroupUsersListBox");

        _singleGrid = this.FindControl<Grid>("SingleGrid");
        _groupGrid = this.FindControl<Grid>("GroupGrid");

        _personImage = this.FindControl<Image>("PersonImage");

        TradeContext context = new TradeContext();

        //currentRequest.Userid = user.Id;
        updateUser = context.Users.Where(u => u.Id == user.Id).FirstOrDefault();

        List<string> items = new List<string>();
        var purposes = context.Goals.ToList();
        foreach (var p in purposes)
        {
            string item = p.Name;
            items.Add(item);
        }

        _purposeComboBox.Items = items;
        
        items = new List<string>();
        var divisions = context.Divisions.ToList();
        foreach (var p in divisions)
        {
            string item = p.Name;
            items.Add(item);
        }
        var _divisions = context.Employees.ToList();
        var testtest = context.Employees.Where(d => d.Divisionid == 1).FirstOrDefault();

        _divisionComboBox.Items = items;

        _requestType = requestType;
        currentUser = user;

        currentUser.Photo = "one_person.png";


        if (requestType == 2)
        {
            _singleGrid.IsVisible = false;
            _groupGrid.IsVisible = true;
        }
        
        _startDateCalendarPicker.DisplayDateStart = DateTime.Today.AddDays(1);
        _startDateCalendarPicker.DisplayDateEnd = DateTime.Today.AddDays(15);
        _endDateCalendarPicker.DisplayDateStart = DateTime.Today.AddDays(1);
        _endDateCalendarPicker.DisplayDateEnd = DateTime.Today.AddDays(15);
        _birthdateCalendarPicker.DisplayDateEnd = DateTime.Today.AddYears(-16);
        
        LoadUserData();
    }
    

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void LoadUserData()
    {
        _firstNameTextBox.Text = currentUser.Firstname;
        _grFirstNameTextBox.Text = currentUser.Firstname;
        _lastNameTextBox.Text = currentUser.Lastname;
        _grLastNameTextBox.Text = currentUser.Lastname;
        _patronymicTextBox.Text = currentUser.Patronymic;
        _grPatronymicTextBox.Text = currentUser.Patronymic;
        _serialMaskedTextBox.Text = currentUser.Passport.Substring(0, Math.Min(currentUser.Passport.Length, 4));
        _grSerialMaskedTextBox.Text = currentUser.Passport.Substring(0, Math.Min(currentUser.Passport.Length, 4));
        _numberMaskedTextBox.Text = currentUser.Passport.Substring(5);
        _grNumberMaskedTextBox.Text = currentUser.Passport.Substring(5);
        _emailTextBox.Text = currentUser.Email;
        _grEmailTextBox.Text = currentUser.Email;
        _phoneMaskedTextBox.Text = currentUser.Phone;
        _grPhoneMaskedTextBox.Text = currentUser.Phone;
        try
        {
            DateTime? birth = currentUser.Birthdate?.ToDateTime(new TimeOnly(0, 0));
            _birthdateCalendarPicker.SelectedDate = birth;
            _grBirthdateCalendarPicker.SelectedDate = birth;
        }
        catch (Exception e)
        {

        }

    }

    private async void UploadPhoto_OnClick(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filters.Add(new FileDialogFilter()
        {
            Extensions = { "jpg", "jpeg", "png" }
        });
        var result = await dialog.ShowAsync(this);
        imgName = result[0].Split("\\").Last();
        fileImgName = result[0];

        Bitmap newImg = new Bitmap(fileImgName);
        currentUser.Photo = imgName;
        _personImage.Source = newImg;
    }

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {
        ClearFields();
    }

    private void EnterButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_firstNameTextBox.Text != "" && _lastNameTextBox.Text != "" && _patronymicTextBox.Text != "" &&
            _emailTextBox.Text != "" && _phoneMaskedTextBox.Text != "" && _noteTextBox.Text != "" && _serialMaskedTextBox.Text != ""
            && _numberMaskedTextBox.Text != "" && _purposeComboBox.SelectedIndex != -1 &&
            _birthdateCalendarPicker.SelectedDate != null && _startDateCalendarPicker.SelectedDate != null && _endDateCalendarPicker.SelectedDate != null &&
            _fIOComboBox.SelectedIndex != -1 && _divisionComboBox.SelectedIndex != -1)
        {
            try
            {
                TradeContext context = new TradeContext();
                currentDivisionRequest.Divisionid = _divisionComboBox.SelectedIndex + 1;
                currentDivisionRequest.Fio = _fIOComboBox.SelectedItem.ToString();

                context.Divisionrequests.Add(currentDivisionRequest);
                context.SaveChanges();

                currentPass.Goalid = _purposeComboBox.SelectedIndex + 1;

                currentPass.Startdate = DateOnly.FromDateTime(_startDateCalendarPicker.SelectedDate.Value);
                currentPass.Enddate = DateOnly.FromDateTime(_endDateCalendarPicker.SelectedDate.Value);
                context.Passes.Add(currentPass);
                context.SaveChanges();
            
            
        
                if (_requestType == 1)
                {
                    updateUser.Firstname = _firstNameTextBox.Text;
                    updateUser.Lastname = _lastNameTextBox.Text;
                    updateUser.Patronymic = _patronymicTextBox.Text;
                    updateUser.Email = _emailTextBox.Text;
                    currentUser.Phone = _phoneMaskedTextBox.Text;
                    currentUser.Passport = _serialMaskedTextBox.Text + " " + _numberMaskedTextBox.Text;
                    currentUser.Birthdate = DateOnly.FromDateTime(_birthdateCalendarPicker.SelectedDate.Value);
                    currentUser.Passportscan = PDFName;

                    context.SaveChanges();
                    
                    currentRequest.Note = _noteTextBox.Text;
                    currentRequest.Organisation = _organizationTextBox.Text;
                    currentRequest.Divisionrequestid = currentDivisionRequest.Id;
                    currentRequest.Passid = currentPass.Id;
                    currentRequest.Userid = currentUser.Id;
                    currentRequest.Typeid = _requestType;

                    context.SaveChanges();
                    
                    context.Requests.Add(currentRequest);
                    context.SaveChanges();

                    if (File.Exists($"../../../Assets/Images/{imgName}"))
                    {
                        //Пропуск добавления фоторгафии
                    }
                    else
                    {
                        File.Copy(fileImgName, $"../../../Assets/Images/{imgName}");
                    }
                    if (File.Exists($"../../../Assets/Files/{PDFName}"))
                    {
                        // Пропуск добавления файла
                    }
                    else
                    {
                        File.Copy(filePDFName, $"../../../Assets/Files/{PDFName}");
                    }
                    
                    MessageWindow messageWindow = new MessageWindow("Вы успешно записались на одиночное посещение");
                    ClearFields();
                    messageWindow.Show();
                }
                
                else if (_requestType == 2)
                {
                    currentGroupUser.Firstname = new string[usersList.Count];
                    currentGroupUser.Lastname = new string[usersList.Count];
                    currentGroupUser.Patronymic = new string[usersList.Count];
                    currentGroupUser.Email = new string[usersList.Count];
                    currentGroupUser.Phone = new string[usersList.Count];
                    currentGroupUser.Passport = new string[usersList.Count];
                    currentGroupUser.Passportscan = new string[usersList.Count];
                    currentGroupUser.Birthdate = new DateOnly[usersList.Count];
                    currentGroupUser.Photo = new string[usersList.Count];
                    currentGroupUser.Passportscan = new string[usersList.Count];
                    
                    for (int i = 0; i < usersList.Count; i++)
                    {
                        currentGroupUser.Firstname[i] = usersList[i].Firstname;
                        currentGroupUser.Lastname[i] = usersList[i].Lastname;
                        currentGroupUser.Patronymic[i] = usersList[i].Patronymic;
                        currentGroupUser.Email[i] = usersList[i].Email;
                        currentGroupUser.Phone[i] = usersList[i].Phone;
                        currentGroupUser.Passport[i] = usersList[i].Passport;
                        currentGroupUser.Passportscan[i] = usersList[i].Passportscan;
                        currentGroupUser.Birthdate[i] = usersList[i].Birthdate;
                        if (usersList[i].Photo != null)
                        {
                            currentGroupUser.Photo[i] = usersList[i].Photo;
                            if (File.Exists($"../../../Assets/Images/{usersList[i].Photo}"))
                            {
                                //Пропуск добавления фоторгафии
                            }
                            else
                            {
                                File.Copy(usersList[i].FullPhotoPath, $"../../../Assets/Images/{usersList[i].Photo}");
                            }
                        }

                        if (usersList[i].Passportscan != null)
                        {
                            currentGroupUser.Passportscan[i] = usersList[i].Passportscan;
                            if (File.Exists($"../../../Assets/Images/{usersList[i].Passportscan}"))
                            {
                                //Пропуск добавления скана пасспорта
                            }
                            else
                            {
                                File.Copy(usersList[i].FullPassportscanPath, $"../../../Assets/Images/{usersList[i].Passportscan}");
                            }
                        }
                    }

                    context.Groupusers.Add(currentGroupUser);
                    context.SaveChanges();
                    
                    currentRequest.Note = _grNoteTextBox.Text;
                    currentRequest.Organisation = _grOrganizationTextBox.Text;
                    currentRequest.Divisionrequestid = currentDivisionRequest.Id;
                    currentRequest.Passid = currentPass.Id;
                    currentRequest.Userid = currentUser.Id;
                    currentRequest.Typeid = _requestType;
                    currentRequest.Groupusers = currentGroupUser.Id;
                    
                    context.Requests.Add(currentRequest);
                    context.SaveChanges();
                    
    

                    if (File.Exists($"../../../Assets/Files/{PDFName}"))
                    {
                        // Пропуск добавления файла
                    }
                    else
                    {
                        File.Copy(filePDFName, $"../../../Assets/Files/{PDFName}");
                    }
                    
                    MessageWindow messageWindow = new MessageWindow("Вы успешно записались на групповое посещение");
                    messageWindow.Show();
                    ClearFields();
                }
            }
            catch (Exception exception)
            {
                TradeContext context = new TradeContext();
                try
                {
                    context.Passes.Remove(currentPass);
                    context.SaveChanges();
                }
                catch (Exception e1)
                {
                    
                }

                try
                {
                    context.Divisionrequests.Remove(currentDivisionRequest);
                    context.SaveChanges();
                }
                catch (Exception e1)
                {

                }

                MessageWindow messageWindow = new MessageWindow("Во время добавления произошла ошибка");
                messageWindow.Show();
            }
        }
        else
        {
            MessageWindow messageWindow = new MessageWindow("Все поля должны быть заполнены");
            messageWindow.Show();
        }

    }

    private void ClearFields()
    {
        try
        {
            _passFIOTextBox.Text = "";
            _lastNameTextBox.Text = "";
            _firstNameTextBox.Text = "";
            _patronymicTextBox.Text = "";
            _phoneMaskedTextBox.Text = "";
            _emailTextBox.Text = "";
            _organizationTextBox.Text = "";
            _noteTextBox.Text = "";
            _serialMaskedTextBox.Text = "";
            _numberMaskedTextBox.Text = "";
            _grLastNameTextBox.Text = "";
            _grFirstNameTextBox.Text = "";
            _grPatronymicTextBox.Text = "";
            _grPhoneMaskedTextBox.Text = "";
            _grEmailTextBox.Text = "";
            _grOrganizationTextBox.Text = "";
            _grNoteTextBox.Text = "";
            _grSerialMaskedTextBox.Text = "";
            _grNumberMaskedTextBox.Text = "";

            _uploadedFileTextBlock.Text = "";
            filePDFName = "";
            currentUser.Photo = "one_person.png";
            Bitmap img = new Bitmap("../../../Assets/one_person.png");
            _personImage.Source = img;

            _purposeComboBox.SelectedIndex = -1;
            _divisionComboBox.SelectedIndex = -1;
            _fIOComboBox.SelectedIndex = -1;

            _startDateCalendarPicker.SelectedDate = null;
            _endDateCalendarPicker.SelectedDate = null;
            _birthdateCalendarPicker.SelectedDate = null;
        }
        catch (Exception e)
        {

        }

    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        ChooseRequestWindow chooseRequestWindow = new ChooseRequestWindow(currentUser);
        chooseRequestWindow.Show();
        this.Close();
    }

    private void DivisionComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TradeContext context = new TradeContext();
        List<string> items = new List<string>();
        try
        {
            var _divisions = context.Employees.Where(d => d.Divisionid == _divisionComboBox.SelectedIndex + 1).ToList();

            foreach (var p in _divisions)
            {
                string item = p.Fio;
                items.Add(item);
            }

            _fIOComboBox.Items = items;
        }
        catch (Exception exception)
        {

        }
    }

    private async void UploadFileButton_OnClick(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filters.Add(new FileDialogFilter()
        {
            Extensions = { "pdf"}
        });
        var result = await dialog.ShowAsync(this);
        PDFName = result[0].Split("\\").Last();
        filePDFName = result[0];
        
        _uploadedFileTextBlock.Text = PDFName;
    }

    private void AddUserButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_grFirstNameTextBox.Text != "" && _grLastNameTextBox.Text != "" && _grPatronymicTextBox.Text != "" &&
            _grEmailTextBox.Text != "" && _grPhoneMaskedTextBox.Text != "" && _grNoteTextBox.Text != "" && _grSerialMaskedTextBox.Text != ""
            && _grNumberMaskedTextBox.Text != "" && _purposeComboBox.SelectedIndex != -1 && _grBirthdateCalendarPicker.SelectedDate != null &&
            _startDateCalendarPicker.SelectedDate != null && _endDateCalendarPicker.SelectedDate != null &&
            _fIOComboBox.SelectedIndex != -1 && _divisionComboBox.SelectedIndex != -1 && _uploadedFileTextBlock.Text != null)
        {
            UserView newUser = new UserView
            {
                Firstname = _grFirstNameTextBox.Text,
                Lastname = _grLastNameTextBox.Text,
                Patronymic = _grPatronymicTextBox.Text,
                Email = _grEmailTextBox.Text,
                Phone = _grPhoneMaskedTextBox.Text,
                Passport = _grSerialMaskedTextBox.Text + " " + _grNumberMaskedTextBox.Text,
                Birthdate = DateOnly.FromDateTime(_grBirthdateCalendarPicker.SelectedDate.Value),
                FIO = _grFirstNameTextBox.Text + " " + _grLastNameTextBox.Text + " " + _grPatronymicTextBox.Text
            };
        
            usersList.Add(newUser);
            _groupUsersListBox.Items = usersList;
        }
    }

    private async void UploadGroupUserPhoto_OnClick(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filters.Add(new FileDialogFilter()
        {
            Extensions = { "jpg", "jpeg", "png" }
        });
        var result = await dialog.ShowAsync(this);
        imgName = result[0].Split("\\").Last();
        fileImgName = result[0];

        Bitmap newImg = new Bitmap(fileImgName);
        UserView obj = ((sender as Button).Parent.Parent.DataContext) as UserView;
        usersList[obj.Id].FullPhotoPath = fileImgName;
        usersList[obj.Id].Photo = imgName;
        _groupUsersListBox.Items = usersList;
    }
}