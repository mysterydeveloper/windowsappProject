using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Graphics.Printing3D;
using Windows.Security.Cryptography;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Navigation;
using windowsappProject.Data;

namespace windowsappProject.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        databaseCalls dbc= new databaseCalls();

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

       

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
        public RelayCommand SetEnterCommand { get; private set; }
        public RelayCommand SetLeaveCommand { get; private set; }

        private void Login()
        {
            Title = "logging in ";

            _navigationService.NavigateTo("LoginPage");

        }
        private void Enter()
        {
            Object username = localSettings.Values["#username"];

            if (username == null)
            {
                Debug.WriteLine("if");
                Login();
            }
            else
            {
                Debug.WriteLine("else");
                Title = (String)username;
            }


        }
        private void leave()
        {
            localSettings.Values["#username"]=null;

        }

        public StartPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Hello Manus";
            SubTitle = "hello i am a subtitle";
            SetLoginCommand = new RelayCommand(Login);
            SetEnterCommand = new RelayCommand(Enter);
            SetLeaveCommand = new RelayCommand(leave);

        }

    }
}
