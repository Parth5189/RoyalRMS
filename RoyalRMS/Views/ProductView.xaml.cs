using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class ProductView : ContentPage
{
    ProductViewModel vm;
    public ProductView()
    {
        InitializeComponent();
        vm = new ProductViewModel();
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
        await vm.LoadProducts();
    }
}