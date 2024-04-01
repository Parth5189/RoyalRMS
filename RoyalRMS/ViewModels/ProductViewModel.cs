using CommunityToolkit.Mvvm.ComponentModel;
using Realms;
using Realms.Sync;
using RoyalRMS.Models;

namespace RoyalRMS.ViewModels
{
    public partial class ProductViewModel : BaseViewModel
    {
        private Realm realm;
        private FlexibleSyncConfiguration config;

        public ProductViewModel()
        {
            User = new CustomerModel
            {
                Email = Preferences.Default.Get("email", "")
            };

        }

        [ObservableProperty]
        CustomerModel user;

        [ObservableProperty]
        List<ProductModel> products;

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
                var resData = realm.All<ProductModel>();
                realm.Subscriptions.Add(resData);
            });

            await realm.Subscriptions.WaitForSynchronizationAsync();

        }
        public async Task LoadProducts()
        {
            try
            {
                Products = realm.All<ProductModel>().AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Close");

            }
        }
    }
}
