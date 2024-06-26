﻿using CommunityToolkit.Mvvm.ComponentModel;
using Realms.Sync;
using Realms;
using RoyalRMS.Models;

namespace RoyalRMS.ViewModels
{
    [QueryProperty(nameof(User), "UserData")]
    public partial class HomeViewModel: BaseViewModel
    {
        private Realm realm;
        private FlexibleSyncConfiguration config;
        public HomeViewModel()
        {
           
        }

        [ObservableProperty]
        CustomerModel user;

        [ObservableProperty]
        List<RestaurantModel> restaurants;

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
                var resData = realm.All<RestaurantModel>();
                realm.Subscriptions.Add(resData);
            });

            await realm.Subscriptions.WaitForSynchronizationAsync();

        }
        public async Task LoadRestaurants()
        {
            try
            {
               
                Restaurants = realm.All<RestaurantModel>().AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Close");

            }
        }
    }

}
