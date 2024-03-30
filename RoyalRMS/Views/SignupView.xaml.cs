using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class SignupView : ContentPage
{
    SignupViewModel vm;

    public SignupView()
    {
        InitializeComponent();
        vm = new SignupViewModel();
        BindingContext = vm;
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("///login");
        return true;
    }
    //private async void OnContinuePressed(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("///verifyotp");
    //}
    private async void OnSignInTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///login");
    }

}