using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Realms.Sync;

namespace RoyalRMS.ViewModels
{
    public partial class LoginViewModel : BaseViewModel

    {
        public LoginViewModel()
        {
            Email = "test@gmail.com";
            Password = "test123";
        }

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;


        [RelayCommand]
        public async Task Login()
        {
            try
            {
                var user = await App.RealmApp.LogInAsync(Credentials.EmailPassword(Email, Password));

                if (user != null)
                {
                    await Shell.Current.GoToAsync("///home");
                    Email = "";
                    Password = "";
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Login unsuccessful!", ex.Message, "Close");
            }

        }

    }
}
