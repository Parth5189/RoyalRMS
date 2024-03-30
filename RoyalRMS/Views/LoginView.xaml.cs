using RoyalRMS.ViewModels;

namespace RoyalRMS.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
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

    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///forgotpass");
    }

    private async void OnSignUpTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///signup");
    }

    //private async void OnSignInClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("///home");
    //}
}