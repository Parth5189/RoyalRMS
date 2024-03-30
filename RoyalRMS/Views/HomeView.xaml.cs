namespace RoyalRMS.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        Task<bool> answer = DisplayAlert("Exit", "Do you want to quit?", "Yes", "No");
        answer.ContinueWith(task =>
        {
            if (task.Result)
            {
                Application.Current.Quit();
            }
        });
        return true;
    }
}