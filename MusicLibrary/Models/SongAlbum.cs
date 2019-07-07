using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class SongAlbum
    {
        public int SongAlbumID { get; set; }
        public int SongID { get; set; }
        public Song Song { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
    }
}
