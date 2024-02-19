namespace RoyalRMS;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void OnContinuePressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OTPVerificationPage());
    }
    private async void OnSignInTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}