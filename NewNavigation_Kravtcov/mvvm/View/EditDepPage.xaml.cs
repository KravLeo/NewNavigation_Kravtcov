using NewNavigation_Kravtcov.mvvm.ViewModel;

namespace NewNavigation_Kravtcov.mvvm.View;

public partial class EditDepPage : ContentPage
{
	public EditDepPage(DepartmentViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}