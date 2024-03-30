using RoyalRMS.Views;

namespace RoyalRMS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(SignupView), typeof(SignupView));
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(CustomerView), typeof(CustomerView));
            Routing.RegisterRoute(nameof(EmployeeView), typeof(EmployeeView));
            Routing.RegisterRoute(nameof(OrderView), typeof(OrderView));
            Routing.RegisterRoute(nameof(ReportView), typeof(ReportView));
            Routing.RegisterRoute(nameof(ProductView), typeof(ProductView));
            Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
            Routing.RegisterRoute(nameof(ForgotPasswordView), typeof(ForgotPasswordView));
            Routing.RegisterRoute(nameof(ChangePasswordView), typeof(ChangePasswordView)); 
            Routing.RegisterRoute(nameof(OTPVerificationView), typeof(OTPVerificationView));
        }
    }
}
