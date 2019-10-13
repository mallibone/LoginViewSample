using LoginViewSample.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginViewSample.Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
		    BindingContext = ViewModel;

	        if (!App.IsUserLoggedIn)
	        {
	            App.NavigationService.NavigateModalAsync(PageNames.LoginPage, false);
	        }
			InitializeComponent();
		}

	    public MainViewModel ViewModel { get; } = new MainViewModel(App.NavigationService);

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();

            if (!App.IsUserLoggedIn)
            {
                await Task.Yield();
                if (App.NavigationService.CurrentPageKey == PageNames.LoginPage) return;
                await App.NavigationService.NavigateModalAsync(PageNames.LoginPage, false);
            }
        }
	}
}
