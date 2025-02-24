namespace NewNavigation_Kravtcov.mvvm.View;
using NewNavigation_Kravtcov.mvvm.ViewModel;

public partial class EmplPage: ContentPage
{
	public EmplPage(EmployeeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}