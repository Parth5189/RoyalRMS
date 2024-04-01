using Microsoft.Extensions.Logging;
using RoyalRMS.ViewModels;
using RoyalRMS.Views;

namespace RoyalRMS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // View Models
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<SignupViewModel>();
            builder.Services.AddSingleton<ForgotPasswordViewModel>();
            builder.Services.AddSingleton<ChangePasswordViewModel>();
            builder.Services.AddTransient<OTPVerifyViewModel>();
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<CustomerViewModel>();
            builder.Services.AddTransient<EmployeeViewModel>();
            builder.Services.AddTransient<ProductViewModel>();
            builder.Services.AddTransient<OrderViewModel>();
            builder.Services.AddTransient<SettingsViewModel>();

            // Views
            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<SignupView>();
            builder.Services.AddTransient<HomeView>();
            builder.Services.AddTransient<CustomerView>();
            builder.Services.AddTransient<EmployeeView>();
            builder.Services.AddTransient<OrderView>();
            builder.Services.AddTransient<ProductView>();
            builder.Services.AddTransient<ReportView>();
            builder.Services.AddSingleton<SettingsView>();
            builder.Services.AddSingleton<ChangePasswordView>();
            builder.Services.AddSingleton<ForgotPasswordView>();
            builder.Services.AddSingleton<OTPVerificationView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
