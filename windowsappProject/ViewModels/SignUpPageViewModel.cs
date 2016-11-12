using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using windowsappProject.Data;
using GalaSoft.MvvmLight;
using Windows.Storage;
using System;
using System.Diagnostics;

namespace windowsappProject.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        databaseCalls dbc = new databaseCalls();
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        Dictionary<string, string> signupfinish = new Dictionary<string, string>();
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

        private string _repassword;
        public string RePassword
        {

            get
            {
                return _repassword;
            }
            set
            {
                if (value != _repassword)
                {
                    _repassword = value;
                    //Debug.WriteLine(_password);
                    RaisePropertyChanged("RePassword");
                }
            }
        }

        private string _email;
        public string Email
        {

            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    //Debug.WriteLine(_password);
                    RaisePropertyChanged("RePassword");
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


        public RelayCommand SetSignUpCommand { get; private set; }

        private void SignupCom()
        {
            signupfinish.Clear();
            Error = " ";
            if (_password != _repassword)
            {
                Error = "passwords dont match";
                return;
            }
            signupfinish.Add("username", _username);
            signupfinish.Add("password", _password);
            signupfinish.Add("email", _email);

            bool signupb = dbc.posttoneo4j("signup", signupfinish);
            if (signupb == true)
            {
                _navigationService.NavigateTo("LoginPage");
            }
            else
            {
                Error = "username taken";
            }
        }

        public SignUpPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Error = "hello ";
            SetSignUpCommand = new RelayCommand(SignupCom);
            Object value = localSettings.Values["username"];

            if (value == null)
            {
                Debug.WriteLine("if");
                SignupCom();
            }
            else
            {
                Debug.WriteLine("else");
                Error = (String)value;
            }
        }
    }
}
