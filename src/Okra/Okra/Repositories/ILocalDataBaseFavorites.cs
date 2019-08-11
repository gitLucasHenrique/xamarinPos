using Okra.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Okra.Repositories
{
    public interface ILocalDataBaseFavorites
    {
        void Add(Anime anime);
        void Edit(Anime anime);
        void Delete(Anime anime);

        List<Anime> GetAll();
        Anime GetById(string id);
    }
}
