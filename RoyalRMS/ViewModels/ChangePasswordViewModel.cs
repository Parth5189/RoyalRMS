
using CommunityToolkit.Mvvm.ComponentModel;

namespace RoyalRMS.ViewModels
{
    public  partial class ChangePasswordViewModel : BaseViewModel
    {
        public ChangePasswordViewModel()
        {
            newPassword = "";
            confirmedPassword = "";
        }

        [ObservableProperty]
        string newPassword;

        [ObservableProperty]
        string confirmedPassword;
    }
}
