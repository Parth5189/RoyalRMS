using Realms.Sync;
using Realms;
using CommunityToolkit.Mvvm.ComponentModel;
using RoyalRMS.Models;

namespace RoyalRMS.ViewModels
{
    public partial class OrderViewModel : BaseViewModel
    {
        private Realm realm;
        private FlexibleSyncConfiguration config;

        public OrderViewModel()
        {
            User = new CustomerModel
            {
                Email = Preferences.Default.Get("email", "")
            };

        }

        [ObservableProperty]
        CustomerModel user;

        [ObservableProperty]
        List<OrderModel> orders;

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
                var resData = realm.All<OrderModel>();
                realm.Subscriptions.Add(resData);
            });

            await realm.Subscriptions.WaitForSynchronizationAsync();

        }
        public async Task LoadOrders()
        {
            try
            {

                Orders = realm.All<OrderModel>().AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Close");

            }
        }
    }
}
