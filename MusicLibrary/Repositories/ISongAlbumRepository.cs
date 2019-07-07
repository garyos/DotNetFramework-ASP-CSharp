using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public interface ISongAlbumRepository
    {
        IQueryable<SongAlbum> SongAlbums();
        void DeleteSongAlbum(SongAlbum salbum);
        void UpdateSongAlbum(SongAlbum salbum);
        void AddSongAlbum(SongAlbum salbum);
        void SaveContext();
        Task<int> SaveContextAsync();
    }
}
