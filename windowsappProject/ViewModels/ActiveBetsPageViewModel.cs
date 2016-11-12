using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windowsappProject.Data;

namespace windowsappProject.ViewModels
{
    public class ActiveBetsPageViewModel  : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        databaseCalls dbc = new databaseCalls();
        PageNav pn ;
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


        public RelayCommand ActiveNavCommand { get; private set; }
        public RelayCommand LatestNavCommand { get; private set; }
        public RelayCommand PreviousNavCommand { get; private set; }
        public RelayCommand MakeNavCommand { get; private set; }
        public RelayCommand ProfileNavCommand { get; private set; }

        public ActiveBetsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            pn = new PageNav(_navigationService);
            ActiveNavCommand = new RelayCommand(pn.ActiveNav);
            LatestNavCommand = new RelayCommand(pn.LatestNav);
            PreviousNavCommand = new RelayCommand(pn.PreviousNav);
            MakeNavCommand = new RelayCommand(pn.MakeBetNav);
            ProfileNavCommand = new RelayCommand(pn.ProfileNav);
        }

    }
}
