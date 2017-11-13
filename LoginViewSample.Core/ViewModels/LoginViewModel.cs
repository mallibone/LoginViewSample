using System.ComponentModel;
using System.Windows.Input;
using LoginViewSample.Core.Services;
using Xamarin.Forms;

namespace LoginViewSample.Core.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private bool _areCredentialsInvalid;

        public LoginViewModel(INavigationService navigationService)
        {
            AuthenticateCommand = new Command(() =>
            {
                AreCredentialsInvalid = !UserAuthenticated(Username, Password);
                if (AreCredentialsInvalid) return;

                navigationService.GoBack();
            });

            AreCredentialsInvalid = false;
        }

        private bool UserAuthenticated(string username, string password)
        {
            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password))
            {
                return false;
            }

            return username.ToLowerInvariant() == "joe" 
                && password.ToLowerInvariant() == "secret";
        }

        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand AuthenticateCommand { get; set; }

        public bool AreCredentialsInvalid
        {
            get => _areCredentialsInvalid;
            set
            {
                if(value == _areCredentialsInvalid) return;
                _areCredentialsInvalid = value;
                OnPropertyChanged(nameof(AreCredentialsInvalid));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
