using Okra.Models;
using Okra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly ILocalDataBaseFavorites localDataBaseFavorites;

        public AnimeService(ILocalDataBaseFavorites localDataBaseFavorites)
        {
            this.localDataBaseFavorites = localDataBaseFavorites;
        }

        public Task Add(Anime anime)
            => Task.Run(() => localDataBaseFavorites.Add(anime));

        public Task<List<Anime>> All()
            => Task.Run(() => localDataBaseFavorites.GetAll());

    }
}
