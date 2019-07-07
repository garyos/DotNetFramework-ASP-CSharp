using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class SongAlbumRepository : ISongAlbumRepository
    {
        private ApplicationDbContext context;
        public SongAlbumRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<SongAlbum> SongAlbums() => context.SongAlbums;
        public void DeleteSongAlbum(SongAlbum salbum) => context.SongAlbums.Remove(salbum);
        public void UpdateSongAlbum(SongAlbum salbum) => context.SongAlbums.Update(salbum);
        public void AddSongAlbum(SongAlbum salbum) => context.SongAlbums.Add(salbum);
        public void SaveContext() => context.SaveChanges();
        public Task<int> SaveContextAsync() => context.SaveChangesAsync();
    }

}
