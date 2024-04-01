
using CommunityToolkit.Mvvm.ComponentModel;

namespace RoyalRMS.ViewModels
{
    public partial class ForgotPasswordViewModel : BaseViewModel
    {
        public ForgotPasswordViewModel()
        {
            Email = "";
        }

        [ObservableProperty]
        string email;
    }
}
