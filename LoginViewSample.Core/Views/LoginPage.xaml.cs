using LoginViewSample.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginViewSample.Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModel;
		}

	    public LoginViewModel ViewModel { get; set; } = new LoginViewModel(App.NavigationService);

	    #region Overrides of Page

	    protected override bool OnBackButtonPressed()
	    {
	        return true;
	    }

	    #endregion
	}
}