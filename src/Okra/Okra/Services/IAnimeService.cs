using Okra.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Okra.Services
{
    public interface IAnimeService
    {
        Task Add(Anime anime);
        Task<List<Anime>> All();
    }
}
