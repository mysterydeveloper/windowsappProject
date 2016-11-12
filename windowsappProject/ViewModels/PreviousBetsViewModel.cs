using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windowsappProject.Data;
using windowsappProject.Model;

namespace windowsappProject.ViewModels
{
    public class PreviousBetsViewModel  : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        databaseCalls dbc = new databaseCalls();
        PageNav pn ;
        PreviousBetsModel pbm = new PreviousBetsModel();
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

        ObservableCollection<BetsViewModel> _Bets
             = new ObservableCollection<BetsViewModel>();
        public ObservableCollection<BetsViewModel> Bets
        {
            get { return _Bets; }
            set
            {
                if (value != _Bets)
                {
                    _Bets = value;
                    RaisePropertyChanged("Bets");
                }
            }
        }
        public PreviousBetsViewModel(INavigationService navigationService)
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
