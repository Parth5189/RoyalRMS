using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class EmployeeView : ContentPage
{
    EmployeeViewModel vm;
    public EmployeeView()
    {
        InitializeComponent();
        vm = new EmployeeViewModel();
        BindingContext = vm;
    }
    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("///home");
        return true;
    }

    protected override async void OnAppearing()
    {
        await vm.InitialiseRealm();
        await vm.LoadEmployees();
    }
}