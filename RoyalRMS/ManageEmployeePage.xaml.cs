using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RoyalRMS;




public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
}

public class MainPageViewModel : INotifyPropertyChanged
{
    public List<Employee> Employees { get; set; }

    public ICommand AddEmployeeCommand { get; }

    public MainPageViewModel()
    {
        // Initialize your list of employees (static data for demonstration)
        Employees = new List<Employee>
            {
                new Employee { Name = "John Doe", Position = "Cook" },
                new Employee { Name = "Jane Smith", Position = "Waiter" },
                // Add more employees as needed
            };

        // Initialize your command (e.g., for adding new employees)
        AddEmployeeCommand = new Command(AddEmployee);
    }

    private void AddEmployee()
    {
        // Implement logic to add a new employee
        // For example, show a dialog or navigate to an add employee page
    }

    // INotifyPropertyChanged implementation (for data binding)
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


public partial class ManageEmployeePage : ContentPage
{
	public ManageEmployeePage()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}