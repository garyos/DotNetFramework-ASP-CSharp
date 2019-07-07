using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public interface ISongGenreRepository
    {
        IQueryable<SongGenre> SongGenres();
        void DeleteSongGenre(SongGenre salbum);
        void UpdateSongGenre(SongGenre salbum);
        void AddSongGenre(SongGenre salbum);
        void SaveContext();
        Task<int> SaveContextAsync();
    }
}
