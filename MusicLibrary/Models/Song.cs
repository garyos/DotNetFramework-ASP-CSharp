using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public ICollection<SongAlbum> SongAlbums { get; set; }
        public ICollection<SongGenre> SongGenres { get; set; }

    }
}
