using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public interface IGenreRepository
    {
        IQueryable<Genre> Genres();
        void DeleteGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void AddGenre(Genre genre);
        void SaveContext();
        Task<int> SaveContextAsync();
    }
}
