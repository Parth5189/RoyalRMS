using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class OTPVerificationView : ContentPage
{
	OTPVerifyViewModel vm;
	public OTPVerificationView()
	{
		InitializeComponent();
		vm = new OTPVerifyViewModel();
	}

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("///forgotpass");
        return true;
    }

    private async void OnClickCancel(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///login");
    }

    private async void OnClickVerify(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///changepass");
    }

}