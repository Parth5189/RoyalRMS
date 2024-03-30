using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Realms.Sync;


namespace RoyalRMS.ViewModels
{
    public partial class SignupViewModel : BaseViewModel

    {
        public SignupViewModel()
        {
            Email = "test@gmail.com";
            Password = "test123";
            Name = "Test_user";
            Phone = "6205798109";
            IsChecked = false;
        }

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string name; 
        
        [ObservableProperty]
        string phone;

        [ObservableProperty]
        bool isChecked;

        [RelayCommand]
        public async void CreateAccount()
        {
            try
            {
                if (IsChecked)
                {
                    await App.RealmApp.EmailPasswordAuth.RegisterUserAsync(Email, Password);
                    await Login();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Required", "Please agree to privacy policy to proceed", "Close");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error creating account!", "Error: " + ex.Message, "Close");
            }
        }

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
                    Name = "";
                    Phone = "";
                    IsChecked = false;
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
