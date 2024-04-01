using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class CustomerView : ContentPage
{
    CustomerViewModel vm;
    public CustomerView()
	{
		InitializeComponent();
        vm = new CustomerViewModel();
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
        await vm.LoadCustomers();
    }
}