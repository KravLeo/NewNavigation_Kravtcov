using Microsoft.Extensions.Logging;
using NewNavigation_Kravtcov.mvvm.View;
using NewNavigation_Kravtcov.mvvm.ViewModel;
using NewNavigation_Kravtcov.mvvm.Model.FakeDB;
using NewNavigation_Kravtcov.mvvm.Model;
using NewNavigation_Kravtcov.mvvm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace NewNavigation_Kravtcov;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
       
        // Регистрация сервисов
        builder.Services.AddSingleton<FakeDB>();
        builder.Services.AddSingleton<UserDB>();
        builder.Services.AddSingleton<Department>();
        builder.Services.AddSingleton<Employee>();
        builder.Services.AddSingleton<User>();

        // Регистрация ViewModel
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<DepartmentViewModel>();
        builder.Services.AddTransient<EmployeeViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();


        // Регистрация страниц
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<DepPage>();
        builder.Services.AddTransient<EmplPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<EditDepPage>();
        builder.Services.AddTransient<EditEmplPage>();
        // Регистрация AppShell
        builder.Services.AddSingleton<AppShell>();

        return builder.Build();
	}
}
