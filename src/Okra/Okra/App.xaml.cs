using Okra.Repositories;
using Okra.Services;
using Okra.ViewModels;
using Okra.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace Okra
{
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
        }

        public App(IPlatformInitializer platformInitializer, bool setFormsDependencyResolver)
            : base(platformInitializer, setFormsDependencyResolver)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"NavigationPage/{nameof(HomePage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();

            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<AnimesView, AnimesViewModel>();
            containerRegistry.RegisterForNavigation<AnimeDetails, AnimeDetailsViewModel>();

            containerRegistry.RegisterForNavigation<FavoritesPage, FavoritesViewModel>();


            containerRegistry.Register<IRecipeService, RecipeService>();
            containerRegistry.Register<ILocalDataBaseRepository, LocalDataBaseRepository>();

            containerRegistry.Register<IAnimeService, AnimeService>();
            containerRegistry.Register<IAnimeDetailsService, AnimeDetailsService>();
            containerRegistry.Register<ILocalDataBaseFavorites, LocalDataBaseFavorites>();
        }
    }
}
