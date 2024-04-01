using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class ChangePasswordView : ContentPage
{
    ChangePasswordViewModel vm;
	public ChangePasswordView()
	{
		InitializeComponent();
        vm = new ChangePasswordViewModel();
        BindingContext = vm;
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("///verifyotp");
        return true;
    }

    private async void OnPasswordChangeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///login");
    }
}