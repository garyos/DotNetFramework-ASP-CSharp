using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public interface ISongRepository
    {
        IQueryable<Song> Songs();
        IQueryable<Album> Albums();
        IQueryable<Genre> Genres();
        void DeleteSong(Song song);
        void UpdateSong(Song song);
        void AddSong(Song song);
        void SaveContext();

        void DeleteSongAlbum(SongAlbum songAlbum);
        void DeleteSongGenre(SongGenre songGenre);
       
        Task<int> SaveContextAsync();

    }
}
