using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibrary.Controllers
{
    public class SongAlbumController : Controller
    {
        private ISongAlbumRepository repository;

        public SongAlbumController(ISongAlbumRepository repo)
        {
            repository = repo;


        }
        public ViewResult List() => View(repository.SongAlbums());

        public ViewResult RemoveSongAlbum(int? id)
        {
            SongAlbum sa = repository.SongAlbums().Single(a => a.SongAlbumID == id);
            repository.DeleteSongAlbum(sa);
            repository.SaveContext();

            return View();
        }

    }
}
