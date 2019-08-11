using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Okra.Models;
using Okra.Services;
using Prism.Commands;
using Prism.Navigation;

namespace Okra.ViewModels
{
    class FavoritesViewModel : BaseViewModel
    {
        private ObservableCollection<Anime> animes;
        private IAnimeService animeService;

        public FavoritesViewModel(INavigationService navigationService, IAnimeService animeService) : base(navigationService)
        {
            this.animeService = animeService;
            //Favoritar = new DelegateCommand(async () => await FavoritarExecute())
             //   .ObservesCanExecute(() => IsNotBusy);
        }

        //private async Task FavoritarExecute()
        //{
        //    await ExecuteBusyAction(async () =>
        //    {
        //        var anime = Anime.Create();
        //        await animeService.Add(anime);
        //    });
        //}

        public ICommand Favoritar { get; }
        public ObservableCollection<Anime> AnimesFromDB
        {
            get => animes;
            set => SetProperty(ref animes, value);
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            await ExecuteBusyAction(async () =>
            {
                await LoadAnimes();
            });
        }

        private async Task LoadAnimes()
        {
            var collection = await animeService.All();
            AnimesFromDB = new ObservableCollection<Anime>(collection);
        }

        protected new async Task ExecuteBusyAction(Func<Task> theBusyAction)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                await theBusyAction();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
