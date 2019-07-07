using MusicLibrary.Models;
using MusicLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class CollectiveRepository : ICollectiveRepository
    {
        private ApplicationDbContext context;
        public CollectiveRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Song> Songs() => context.Songs;
        public IQueryable<Album> Albums() => context.Albums;
        public IQueryable<Genre> Genres() => context.Genres;
        public IQueryable<SongAlbum> SongAlbums() => context.SongAlbums;
        public IQueryable<SongGenre> SongGenres() => context.SongGenres;

        public void DeleteAlbum(Album album) => context.Albums.Remove(album);
        public void UpdateAlbum(Album album) => context.Albums.Update(album);
        public void AddAlbum(Album album) => context.Albums.Add(album);
        public void SaveContext() => context.SaveChanges();
        public Task<int> SaveContextAsync() => context.SaveChangesAsync();

        public void DeleteSong(Song song) => context.Songs.Remove(song);
        public void UpdateSong(Song song) => context.Songs.Update(song);
        public void AddSong(Song song) => context.Songs.Add(song);

        public void DeleteGenre(Genre genre) => context.Genres.Remove(genre);

        public void DeleteSongAlbumRows(List<SongAlbum> sa) => context.SongAlbums.RemoveRange(sa);
        public void DeleteSongGenreRows(List<SongGenre> sg) => context.SongGenres.RemoveRange(sg);
    }
}
