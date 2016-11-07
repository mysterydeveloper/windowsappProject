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
            _navigationService.NavigateTo("StartPage");

        }
        public void LatestNav()
        {
            _navigationService.NavigateTo("StartPage");
        }

        public void MakeBetNav()
        {
            _navigationService.NavigateTo("StartPage");
        }
        public void PreviousNav()
        {
            _navigationService.NavigateTo("StartPage");

        }
        public void ActiveNav()
        {
            _navigationService.NavigateTo("StartPage");
        }

        public PageNav(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
