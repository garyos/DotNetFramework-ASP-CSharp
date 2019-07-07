using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class SongGenreRepository : ISongGenreRepository
    {
        private ApplicationDbContext context;
        public SongGenreRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<SongGenre> SongGenres() => context.SongGenres;
        public void DeleteSongGenre(SongGenre sgenre) => context.SongGenres.Remove(sgenre);
        public void UpdateSongGenre(SongGenre sgenre) => context.SongGenres.Update(sgenre);
        public void AddSongGenre(SongGenre sgenre) => context.SongGenres.Add(sgenre);
        public void SaveContext() => context.SaveChanges();
        public Task<int> SaveContextAsync() => context.SaveChangesAsync();
    }
}
