using System;
using System.Collections.Generic;
using System.Text;
using Okra.Models;
using Prism.Navigation;

namespace Okra.ViewModels
{
    class AnimeDetailsViewModel : BaseViewModel
    {
        public AnimeDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        private Anime _anime;
        public Anime Anime
        {
            get => _anime;
            set
            {
                SetProperty(ref _anime, value);
            }
        } 
    }
}
