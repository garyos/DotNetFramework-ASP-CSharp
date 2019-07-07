using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibrary.Controllers
{
    public class SongGenreController : Controller
    {
        private ISongGenreRepository repository;

        public SongGenreController(ISongGenreRepository repo)
        {
            repository = repo;


        }
        public ViewResult List() => View(repository.SongGenres());

        public ViewResult RemoveSongGenre(int? id)
        {
            SongGenre sg = repository.SongGenres().Single(a => a.SongGenreID == id);
            repository.DeleteSongGenre(sg);
            repository.SaveContext();

            return View();
        }

    }
}
