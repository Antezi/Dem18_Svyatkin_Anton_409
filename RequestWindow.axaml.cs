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

public partial class RequestWindow : Window
{
    private Request currentRequest;
    private List<Purpose> purposesLists;
    private User currentUser;
    private string imgName, fileImgName;
    private int _requestType;
    private ComboBox _purposeComboBox, _divisionComboBox;
    private Image _personImage; 
    private CalendarDatePicker  _startDateCalendarPicker, _endDateCalendarPicker, _birthdateCalendarPicker;

    private TextBox _passFIOTextBox,
        _lastNameTextBox,
        _firstNameTextBox,
        _patronymicTextBox,
        _phoneTextBox,
        _emailTextBox,
        _organizationTextBox,
        _noteTextBox,
        _serialTextBox,
        _numberTextBox;
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
        _phoneTextBox = this.FindControl<TextBox>("PhoneTextBox");
        _emailTextBox = this.FindControl<TextBox>("EmailTextBox");
        _organizationTextBox = this.FindControl<TextBox>("OrganizationTextBox");
        _noteTextBox = this.FindControl<TextBox>("NoteTextBox");
        _serialTextBox = this.FindControl<TextBox>("SerialTextBox");
        _numberTextBox = this.FindControl<TextBox>("NumberTextBox");

        _purposeComboBox = this.FindControl<ComboBox>("PurposeComboBox");
        _divisionComboBox = this.FindControl<ComboBox>("DivisionComboBox");

        _startDateCalendarPicker = this.FindControl<CalendarDatePicker>("StartDateCalendarPicker");
        _endDateCalendarPicker = this.FindControl<CalendarDatePicker>("EndDateCalendarPicker");
        _birthdateCalendarPicker = this.FindControl<CalendarDatePicker>("BirthdateCalendarPicker");

        _personImage = this.FindControl<Image>("PersonImage");

        TradeContext context = new TradeContext();

        List<string> items = new List<string>();
        var purposes = context.Purposes.ToList();
        foreach (var p in purposes)
        {
            string item = p.Name;
            items.Add(item);
        }

        _purposeComboBox.Items = items;
        
        var divisions = context.Divisions.ToList();
        foreach (var p in divisions)
        {
            string item = p.Name;
            items.Add(item);
        }

        _divisionComboBox.Items = items;

        _requestType = requestType;
        currentUser = user;
    }
    

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
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
        currentRequest.Photo = imgName;
        //_personImage.Source = newImg;
    }

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {

    }

    private void EnterButton_OnClick(object? sender, RoutedEventArgs e)
    {

    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        ChooseRequestWindow chooseRequestWindow = new ChooseRequestWindow(currentUser);
        chooseRequestWindow.Show();
        this.Close();
    }
}