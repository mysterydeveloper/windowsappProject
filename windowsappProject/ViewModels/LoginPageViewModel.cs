using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using windowsappProject.Models;

namespace windowsappProject.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        databaseCalls dbc = new databaseCalls();
        Dictionary<string, string> loginfinish = new Dictionary<string, string>();
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

        private string _username;
        public string Username
        {

            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    Debug.WriteLine(_username);
                    RaisePropertyChanged("Title");
                }
            }
        }
        private string _password;
        public string Password
        {

            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    Debug.WriteLine(_password);
                    RaisePropertyChanged("Title");
                }
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
                    RaisePropertyChanged("TestMessage");
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
            loginfinish.Clear();
            Title = "logging in ";
            loginfinish.Add("username", _username);
            loginfinish.Add("password", _password);
            _navigationService.NavigateTo("LoginPage");
            dbc.posttoneo4j("Login", loginfinish);
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Hello login";
            SubTitle = "hello i am a login subtitle";
            SetLoginCommand = new RelayCommand(Login);
        }
    }
}