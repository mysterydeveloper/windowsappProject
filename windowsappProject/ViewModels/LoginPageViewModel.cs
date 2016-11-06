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
                    //Debug.WriteLine(_username);
                    RaisePropertyChanged("Username");
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
                    //Debug.WriteLine(_password);
                    RaisePropertyChanged("Password");
                }
            }
        }

        private string _error;
        public string Error
        {

            get
            {
                return _error;
            }
            set
            {
                if (value != _error)
                {
                    _error = value;
                    RaisePropertyChanged("Error");
                }
            }
        }


        public RelayCommand SetLoginCommand { get; private set; }

        public RelayCommand SetSignupCommand { get; private set; }

        private void Signuppage()
        {
            _navigationService.NavigateTo("SignupPage");
        }

        private void Login()
        {
            loginfinish.Clear();
            Error = "logging in ";
            loginfinish.Add("username", _username);
            loginfinish.Add("password", _password);
            bool loginb=dbc.posttoneo4j("Login", loginfinish);
            if (loginb == true)
            {
                _navigationService.NavigateTo("StartPage");
            }
            else
            {
                Error = "username or password incorrect";
            }
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Error = " ";
            SetLoginCommand = new RelayCommand(Login);
            SetSignupCommand = new RelayCommand(Signuppage);
        }
    }
}