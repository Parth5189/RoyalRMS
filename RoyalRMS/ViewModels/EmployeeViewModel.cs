using Realms.Sync;
using Realms;
using CommunityToolkit.Mvvm.ComponentModel;
using RoyalRMS.Models;
using CommunityToolkit.Mvvm.Input;

namespace RoyalRMS.ViewModels
{
    public partial class EmployeeViewModel : BaseViewModel
    {
        private Realm realm;
        private FlexibleSyncConfiguration config;

        public EmployeeViewModel()
        {
            User = new CustomerModel
            {
                Email = Preferences.Default.Get("email", "")
            };

        }

        [ObservableProperty]
        CustomerModel user;

        [ObservableProperty]
        List<EmployeeModel> employees;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string phone;

        [ObservableProperty]
        string position;

        [ObservableProperty]
        string salary;

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
                var resData = realm.All<EmployeeModel>();
                realm.Subscriptions.Add(resData);
            });

            await realm.Subscriptions.WaitForSynchronizationAsync();

        }
        public async Task LoadEmployees()
        {
            try
            {

                Employees = realm.All<EmployeeModel>().AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Close");

            }
        }

        [RelayCommand]
        public async Task CreateData()
        {
            try
            {
                var newEmp = new EmployeeModel
                {
                    Name = Name,
                    Email = Email,
                    Position = Position,
                    Phone = Phone,
                    Salary = double.Parse(Salary, System.Globalization.CultureInfo.InvariantCulture)
            };

                realm.Write(() =>
                {
                    realm.Add(newEmp);
                });

                await Application.Current.MainPage.DisplayAlert("Success", "Employee details added", "Ok");


                Name = "";
                Email = "";
                Position = "";
                Phone = "";
                Salary = "";

                await LoadEmployees();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Close");

            }
        }
    }
}
