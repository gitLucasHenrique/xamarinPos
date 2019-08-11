using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using Okra.Models;
using Okra.Services;

namespace Okra.Repositories
{
    public sealed class LocalDataBaseFavorites : ILocalDataBaseFavorites
    {
        private const string COLLECTION_NAME = "animes";

        private readonly LiteCollection<Anime> liteCollection;
        private readonly IDataBaseAccessService dataBaseAccessService;

        public LocalDataBaseFavorites(IDataBaseAccessService dataBaseAccessService)
        {
            this.dataBaseAccessService = dataBaseAccessService;
            liteCollection = GetCollection();
        }

        public void Add(Anime anime)
            => liteCollection.Insert(anime);

        public void Delete(Anime anime)
            => liteCollection.Delete(anime.Id);

        public void Edit(Anime anime)
            => liteCollection.Update(anime);

        public List<Anime> GetAll()
            => liteCollection.FindAll().ToList();

        public Anime GetById(string id)
            => liteCollection.FindById(id);

        private LiteCollection<Anime> GetCollection()
        {
            var db = GetOrCreateLiteDatabase();
            return db.GetCollection<Anime>(COLLECTION_NAME);
        }

        private LiteDatabase GetOrCreateLiteDatabase()
        {
            var dbPath = dataBaseAccessService.GetDataBasePath();
            return new LiteDatabase($@"{dbPath}");
        }
    }
}
