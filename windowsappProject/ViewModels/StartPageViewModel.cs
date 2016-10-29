using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;

namespace windowsappProject.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

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

        public RelayCommand SetTextCommand { get; private set; }

        private void HandleSetText()
        {
            Title = "logging in ";
            _navigationService.NavigateTo("LoginPage");

        }

        public StartPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Hello Manus";
            SubTitle = "hello i am a subtitle";
            SetTextCommand = new RelayCommand(HandleSetText);
        }
    }
}
