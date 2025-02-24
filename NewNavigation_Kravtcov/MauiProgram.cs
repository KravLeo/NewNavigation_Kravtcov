using Microsoft.Extensions.Logging;
using NewNavigation_Kravtcov.mvvm.View;
using NewNavigation_Kravtcov.mvvm.ViewModel;
using NewNavigation_Kravtcov.mvvm.Model.FakeDB;
using NewNavigation_Kravtcov.mvvm.Model;

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
        builder.Services.AddSingleton<Department>();
        builder.Services.AddSingleton<Employee>();

        // Регистрация ViewModel
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<DepartmentViewModel>();
        builder.Services.AddTransient<EmployeeViewModel>();

        // Регистрация страниц
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<DepPage>();
        builder.Services.AddTransient<EmplPage>();

        // Регистрация AppShell
        builder.Services.AddSingleton<AppShell>();

        return builder.Build();
	}
}
