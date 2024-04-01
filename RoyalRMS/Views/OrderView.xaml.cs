using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class OrderView : ContentPage
{
    OrderViewModel vm;
    public OrderView()
    {
        InitializeComponent();
        vm = new OrderViewModel();
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
        await vm.LoadOrders();
    }
}