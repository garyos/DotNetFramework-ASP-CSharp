using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class AlbumRepository : IAlbumRepository
    {
        private ApplicationDbContext context;
        public AlbumRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Album> Albums() => context.Albums;
        public void DeleteAlbum(Album album) => context.Albums.Remove(album);
        public void UpdateAlbum(Album album) => context.Albums.Update(album);
        public void AddAlbum(Album album) => context.Albums.Add(album);
        public void SaveContext() => context.SaveChanges();
        public Task<int> SaveContextAsync() => context.SaveChangesAsync();

    }
}
