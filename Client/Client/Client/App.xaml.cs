using Prism;
using Prism.Ioc;
using Client.ViewModels;
using Client.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Client.Interfaces;
using Client.Services;
using Client.ApiWrapperImplementation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Client
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/TeamsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.Register<IFacade, Facade>();
            containerRegistry.Register<IApiWrapper, ApiWrapper>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<AircraftInfoPage, AircraftInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<EmployeesPage, EmployeesPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateTasksPage, CreateTasksPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateTeamsPage, CreateTeamsPageViewModel>();
            containerRegistry.RegisterForNavigation<AircraftTasksPage, AircraftTasksPageViewModel>();
            containerRegistry.RegisterForNavigation<TeamsPage, TeamsPageViewModel>();
            containerRegistry.RegisterForNavigation<TeamDetailsPage, TeamDetailsPageViewModel>();
        }
    }
}
