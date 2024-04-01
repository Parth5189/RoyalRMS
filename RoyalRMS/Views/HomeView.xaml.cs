using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class HomeView : ContentPage
{
    HomeViewModel vm;
	public HomeView()
	{
		InitializeComponent();
        vm = new HomeViewModel();
        BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        await vm.InitialiseRealm();
        await vm.LoadRestaurants();
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