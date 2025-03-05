using NewNavigation_Kravtcov.mvvm.ViewModel;

namespace NewNavigation_Kravtcov.mvvm.View;

public partial class EditEmplPage : ContentPage
{
	public EditEmplPage(EmployeeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}