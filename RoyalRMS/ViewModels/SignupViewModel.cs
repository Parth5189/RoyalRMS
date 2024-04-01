using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Realms;
using Realms.Sync;
using RoyalRMS.Models;


namespace RoyalRMS.ViewModels
{
    public partial class SignupViewModel : BaseViewModel

    {
        private Realm realm;
        private FlexibleSyncConfiguration config;
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

        public async Task InitialiseRealm()
        {
            var cUser = App.RealmApp.CurrentUser;
            if (cUser == null)
            {
                await Application.Current.MainPage.DisplayAlert("Session expired", "User not logged in", "Close");
                return;
            }
            config = new FlexibleSyncConfiguration(cUser);
            realm = await Realm.GetInstanceAsync(config);

            realm.Subscriptions.Update(() =>
            {
                var currentUser = realm.All<CustomerModel>().Where(t => t.Email == Email);
                realm.Subscriptions.Add(currentUser);
            });

            await realm.Subscriptions.WaitForSynchronizationAsync();

        }

        public async Task AddUser()
        {
            await InitialiseRealm();
            try
            {
                var newUser = new CustomerModel
                {
                    Name = Name,
                    Email = Email,
                    Phone = Phone,
                    Password = Password,
                };
                realm.Write(() =>
                {
                    realm.Add(newUser);
                });
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Close");

            }

        }

        [RelayCommand]
        public async void CreateAccount()
        {
            try
            {
                if (IsChecked)
                {
                    await App.RealmApp.EmailPasswordAuth.RegisterUserAsync(Email, Password);
                    var user = await App.RealmApp.LogInAsync(Credentials.EmailPassword(Email, Password));
                    await AddUser();
                    await Login(user);
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
        public async Task Login(User user)
        {
            try
            {
                if (user != null)
                {
                    Preferences.Default.Set("email", Email);
                    await Shell.Current.GoToAsync("///home",
                        new Dictionary<string, object>()
                        {
                            { "UserData", new CustomerModel{

                                       Email = Email
                            }
                           }
                        });
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
