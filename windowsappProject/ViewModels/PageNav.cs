using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsappProject.ViewModels
{
    public class PageNav
    {
        private readonly INavigationService _navigationService;
        public void ProfileNav()
        {
            _navigationService.NavigateTo("ProfilePage");

        }
        public void LatestNav()
        {
            _navigationService.NavigateTo("LatestBetsPage");
        }
        public void MakeBetNav()
        {
            _navigationService.NavigateTo("MakePendingPage");
        }
        public void PreviousNav()
        {
            _navigationService.NavigateTo("PreviousBetsPage");

        }
        public void ActiveNav()
        {
            _navigationService.NavigateTo("ActiveBetsPage");
        }

        public PageNav(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
