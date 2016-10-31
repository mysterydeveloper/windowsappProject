using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Neo4j.Driver.V1;
using System.Diagnostics;

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

        public RelayCommand SetLoginCommand { get; private set; }

        private void Login()
        {
            Title = "logging in ";

            _navigationService.NavigateTo("LoginPage");

        }
        public  void posttoneo4j()
        {
            using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "manus")))
            using (var session = driver.Session())
            {
                session.Run("CREATE (a:Person {name:'Arthur', title:'King'})");
                var result = session.Run("MATCH (a:Person) WHERE a.name = 'Arthur' RETURN a.name AS name, a.title AS title");

                foreach (var record in result)
                {
                    Debug.WriteLine($"{record["title"].As<string>()} {record["name"].As<string>()}");
                }
            }
        }

        public StartPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Hello Manus";
            SubTitle = "hello i am a subtitle";
            posttoneo4j();
            SetLoginCommand = new RelayCommand(Login);
        }
    }
}
