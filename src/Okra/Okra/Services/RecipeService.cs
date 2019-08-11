using System.Collections.Generic;
using System.Threading.Tasks;
using Okra.Models;
using Okra.Repositories;

namespace Okra.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ILocalDataBaseRepository localDataBaseRepository;

        public RecipeService(ILocalDataBaseRepository localDataBaseRepository)
        {
            this.localDataBaseRepository = localDataBaseRepository;
        }

        public Task Add(Recipe recipe)
            => Task.Run(() => localDataBaseRepository.Add(recipe));

        public Task<List<Recipe>> All()
            => Task.Run(() => localDataBaseRepository.GetAll());

    }
}
