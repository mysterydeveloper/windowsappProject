
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windowsappProject.Views;

namespace windowsappProject.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary> 
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        /// 
        public const string StartPageKey = "StartPage";
        public const string LoginPageKey = "LoginPage";
        public const string SignupPageKey = "SignupPage";
        public const string ProfilePageKey = "ProfilePage";
        public const string ActiveBetsPageKey = "ActiveBetsPage";
        public const string LatestBetsPageKey = "LatestBetsPage";
        public const string PreviousBetsPageKey = "PreviousBetsPage";
        public const string MakePendingPageKey = "MakePendingPage";
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();
            nav.Configure(StartPageKey, typeof(StartPage));
            nav.Configure(LoginPageKey, typeof(LoginPage));
            nav.Configure(SignupPageKey, typeof(SignUpPage));
            nav.Configure(ProfilePageKey, typeof(ProfilePage));
            nav.Configure(ActiveBetsPageKey, typeof(ActiveBetsPage));
            nav.Configure(LatestBetsPageKey, typeof(LatestBetsPage));
            nav.Configure(PreviousBetsPageKey, typeof(PreviousBetsPage));
            nav.Configure(MakePendingPageKey, typeof(MakePendingPage));
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<StartPageViewModel>();
            SimpleIoc.Default.Register<LoginPageViewModel>();
            SimpleIoc.Default.Register<SignUpPageViewModel>();
            SimpleIoc.Default.Register<ProfilePageViewModel>();
            SimpleIoc.Default.Register<ActiveBetsPageViewModel>();
            SimpleIoc.Default.Register<LatestBetsPageViewModel>();
            SimpleIoc.Default.Register<PreviousBetsViewModel>();
            SimpleIoc.Default.Register<MakePendingPageViewModel>();
        }


        // <summary>
        // Gets the StartPage view model.
        // </summary>
        // <value>
        // The StartPage view model.
        // </value>
        public StartPageViewModel StartPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartPageViewModel>();
            }
        }

        public LoginPageViewModel LoginPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginPageViewModel>();
            }
        }
        public SignUpPageViewModel SignUpPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SignUpPageViewModel>();
            }
        }
        public ProfilePageViewModel ProfilePageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProfilePageViewModel>();
            }
        }
        public ActiveBetsPageViewModel ActivePageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ActiveBetsPageViewModel>();
            }
        }
        public LatestBetsPageViewModel LatestBetsPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LatestBetsPageViewModel>();
            }
        }

        public PreviousBetsViewModel PreviousBetsPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PreviousBetsViewModel>();
            }
        }

        public MakePendingPageViewModel MakePendingPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MakePendingPageViewModel>();
            }
        }


        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

}
