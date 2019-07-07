using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Repositories
{
    public interface ICollectiveRepository
    {
        IQueryable<Song> Songs();
        IQueryable<Album> Albums();
        IQueryable<Genre> Genres();
        IQueryable<SongAlbum> SongAlbums();
        IQueryable<SongGenre> SongGenres();

        void DeleteAlbum(Album album);
        void UpdateAlbum(Album album);
        void AddAlbum(Album album);
        void SaveContext();
        Task<int> SaveContextAsync();

        void DeleteSong(Song song);
        void UpdateSong(Song song);
        void AddSong(Song song);

        void DeleteGenre(Genre genre);

        void DeleteSongAlbumRows(List<SongAlbum> sa);
        void DeleteSongGenreRows(List<SongGenre> sg);
    }
}
