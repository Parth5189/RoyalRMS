using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class ForgotPasswordView : ContentPage
{
    ForgotPasswordViewModel vm;
	public ForgotPasswordView()
	{
		InitializeComponent();
        vm = new ForgotPasswordViewModel();
        BindingContext = vm;
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("///login");
        return true;
    }

    private async void OnClickCancel(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///login");
    }

    private async void OnClickOTPSend(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///verifyotp");
    }
}