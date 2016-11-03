using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using windowsappProject.Models;

namespace windowsappProject.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        databaseCalls dbc= new databaseCalls();

        private bool _isLoading = false;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");

            }
        }

        private string _title;
        public string Title
        {

            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        private string _subtitle;
        public string SubTitle
        {

            get
            {
                return _subtitle;
            }
            set
            {
                if (value != _subtitle)
                {
                    _subtitle = value;
                    RaisePropertyChanged("SubTitle");
                }
            }
        }

        public RelayCommand SetLoginCommand { get; private set; }

        private void Login()
        {
            Title = "logging in ";

            _navigationService.NavigateTo("LoginPage");

        }

        public StartPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Hello Manus";
            SubTitle = "hello i am a subtitle";
            SetLoginCommand = new RelayCommand(Login);
            dbc.posttoneo4j("signup");
        }
    }
}
