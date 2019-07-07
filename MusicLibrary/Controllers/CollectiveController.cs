using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Models;
using MusicLibrary.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibrary.Controllers
{
    public class CollectiveController : Controller
    {
        private ICollectiveRepository repository;

        public CollectiveController(ICollectiveRepository repo)
        {
            repository = repo;
        }



        public ViewResult RemoveSong(int? id)
        {
            Song s = repository.Songs().Single(a => a.SongID == id);
            var sa = repository.SongAlbums().Where(b => b.SongID == id);
            List<SongAlbum> saList = sa.ToList();

            var sg = repository.SongGenres().Where(c => c.SongID == id);
            List<SongGenre> sgList = sg.ToList();

            repository.DeleteSongAlbumRows(saList);
            repository.DeleteSongGenreRows(sgList);
            repository.DeleteSong(s);
            repository.SaveContext();

            return View(s);
        }

        public ViewResult RemoveAlbum(int? id)
        {
            Album a = repository.Albums().Single(b => b.AlbumID == id);

            var sa = repository.SongAlbums().Where(b => b.AlbumID == id);
            List<SongAlbum> saList = sa.ToList();

            repository.DeleteSongAlbumRows(saList);
            repository.DeleteAlbum(a);
            repository.SaveContext();

            return View(a);
        }


        public ViewResult RemoveGenre(int? id)
        {
            Genre g = repository.Genres().Single(b => b.GenreID == id);

            var sg = repository.SongGenres().Where(b => b.GenreID == id);
            List<SongGenre> sgList = sg.ToList();

            repository.DeleteSongGenreRows(sgList);
            repository.DeleteGenre(g);
            repository.SaveContext();

            return View(g);
        }
    }
}
