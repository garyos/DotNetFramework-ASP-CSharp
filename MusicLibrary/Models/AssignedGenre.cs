﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class AssignedGenre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }

    }
}
