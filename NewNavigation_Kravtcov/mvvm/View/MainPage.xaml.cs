using NewNavigation_Kravtcov.mvvm.Model.FakeDB;
using NewNavigation_Kravtcov.mvvm.ViewModel;
using NewNavigation_Kravtcov.mvvm.Model;
namespace NewNavigation_Kravtcov.mvvm.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

}