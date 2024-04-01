
using CommunityToolkit.Mvvm.ComponentModel;

namespace RoyalRMS.ViewModels
{
    public partial class OTPVerifyViewModel: BaseViewModel
    {
        public OTPVerifyViewModel()
        {
            Otp = ""; 
        }

        [ObservableProperty]
        string otp;
    }
}
