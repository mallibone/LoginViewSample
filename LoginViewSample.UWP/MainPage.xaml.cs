namespace LoginViewSample.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new LoginViewSample.Core.App());
        }
    }
}
