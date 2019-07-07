using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext context;
        public GenreRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Genre> Genres() => context.Genres;
        public void DeleteGenre(Genre genre) => context.Genres.Remove(genre);
        public void UpdateGenre(Genre genre) => context.Genres.Update(genre);
        public void AddGenre(Genre genre) => context.Genres.Add(genre);
        public void SaveContext() => context.SaveChanges();
        public Task<int> SaveContextAsync() => context.SaveChangesAsync();
    }
}
