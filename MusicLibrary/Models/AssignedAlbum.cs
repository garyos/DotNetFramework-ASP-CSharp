using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class AssignedAlbum
    {
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }

    }
}
