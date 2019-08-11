using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Okra.Models;

namespace Okra.Services
{
    public interface IRecipeService
    {
        Task Add(Recipe recipe);
        Task<List<Recipe>> All();
    }
}
