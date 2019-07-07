using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MusicLibrary.Models
{
    public class SongRepository : ISongRepository
    {
        private ApplicationDbContext context;
        public SongRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Song> Songs() => context.Songs;
        public IQueryable<Album> Albums() => context.Albums;
        public IQueryable<Genre> Genres() => context.Genres;
        public void DeleteSong(Song song) => context.Songs.Remove(song);
        public void UpdateSong(Song song) => context.Songs.Update(song);
        public void AddSong(Song song) => context.Songs.Add(song);

        public void DeleteSongAlbum(SongAlbum songAlbum) => context.SongAlbums.Remove(songAlbum);
        public void DeleteSongGenre(SongGenre songGenre) => context.SongGenres.Remove(songGenre);

        public void SaveContext() => context.SaveChanges();
        public Task<int> SaveContextAsync() => context.SaveChangesAsync();

    }
   
}
