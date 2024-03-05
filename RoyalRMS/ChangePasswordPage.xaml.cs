namespace RoyalRMS;

public partial class ChangePasswordPage : ContentPage
{
	public ChangePasswordPage()
	{
		InitializeComponent();
	}

    private async void OnPasswordChangeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageEmployeePage());
    }
}