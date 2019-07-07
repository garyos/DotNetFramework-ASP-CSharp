using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public interface IAlbumRepository
    {
        IQueryable<Album> Albums();
        void DeleteAlbum(Album album);
        void UpdateAlbum(Album album);
        void AddAlbum(Album album);
        void SaveContext();
        Task<int> SaveContextAsync();

    }
}
