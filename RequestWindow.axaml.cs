using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Dem18_Svyatkin_Anton_409;

public partial class RequestWindow : Window
{
    private int _requestType;
    private ComboBox _goalComboBox, _divisionComboBox;
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
        InitializeComponent();
    }
    
    public RequestWindow(int requestType)
    {
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

        _goalComboBox = this.FindControl<ComboBox>("GoalComboBox");
        _divisionComboBox = this.FindControl<ComboBox>("DivisionComboBox");

        _startDateCalendarPicker = this.FindControl<CalendarDatePicker>("StartDateCalendarPicker");
        _endDateCalendarPicker = this.FindControl<CalendarDatePicker>("EndDateCalendarPicker");
        _birthdateCalendarPicker = this.FindControl<CalendarDatePicker>("BirthdateCalendarPicker");

        _personImage = this.FindControl<Image>("PersonImage");
        
        _requestType = requestType;
    }
    

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void UploadPhoto_OnClick(object? sender, RoutedEventArgs e)
    {

    }

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {

    }

    private void EnterButton_OnClick(object? sender, RoutedEventArgs e)
    {

    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {

    }
}