namespace RoyalRMS;

public partial class ForgotPasswordPage : ContentPage
{
	public ForgotPasswordPage()
	{
		InitializeComponent();
	}

    private async void SendOTPPressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OTPVerificationPage());
    }
}