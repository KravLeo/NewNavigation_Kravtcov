using NewNavigation_Kravtcov.mvvm.ViewModel;

namespace NewNavigation_Kravtcov.mvvm.View;
public partial class DepPage : ContentPage
{
	public DepPage(DepartmentViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}