using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Okra.Models;
using Okra.Services;
using Prism.Commands;
using Prism.Navigation;

namespace Okra.ViewModels
{
    public class AnimesViewModel : BaseViewModel
    {
        private ObservableCollection<Anime> animes = new ObservableCollection<Anime>();
        private INavigationService _navigationService;
        private DelegateCommand _navigateCommand;
        private IAnimeService _animeService;
        public AnimesViewModel(INavigationService navigationService, IAnimeService animeService) : base(navigationService)
        {
            _navigationService = navigationService;
            _animeService = animeService;
        }

        public DelegateCommand NCGoAnime =>
                _navigateCommand ?? (_navigateCommand = new DelegateCommand(GoAnime));

        public DelegateCommand NCFavoritar =>
                _navigateCommand ?? (_navigateCommand = new DelegateCommand(Favoritar));

        private void Favoritar()
        {
            Console.WriteLine("favoritar clicado");
        }

        async void GoAnime()
        {
            var param = new NavigationParameters();
            //param.Add(animes);
            await _navigationService.NavigateAsync("AnimeDetails",param);
        }

        public ObservableCollection<Anime> Animes
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
            string apiUrl = "https://tv-v2.api-fetch.website/animes/1";
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(apiUrl);
            var animes = JsonConvert.DeserializeObject<List<Anime>>(response);

            Animes = new ObservableCollection<Anime>(animes);
        }
    }
}
