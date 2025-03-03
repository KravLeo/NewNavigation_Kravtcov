using NewNavigation_Kravtcov.mvvm.Model.FakeDB;
using NewNavigation_Kravtcov.mvvm.ViewModel;
using NewNavigation_Kravtcov.mvvm.Model;
namespace NewNavigation_Kravtcov.mvvm.View;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel mainView;
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = mainView = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await mainView.LoadDataAsync(); // «агружаем данные при открытии страницы
    }
}