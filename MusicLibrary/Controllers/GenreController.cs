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
    public class GenreController : Controller
    {

        private IGenreRepository repository;

        public GenreController(IGenreRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Genres());

        public ViewResult SongsByGenre(int id)
        {
            var songs = repository.Genres().Include(a => a.SongGenres)
                                            .ThenInclude(c => c.Song).Where(d => d.GenreID == id).ToList();

            return View(songs);
        }

        [HttpPost]
        public ViewResult NewGenre()
        {
            Genre newGen = new Genre { Name = Request.Form["Name"] };
            repository.AddGenre(newGen);
            repository.SaveContext();
            return View();
        }

        public ViewResult AddGenre()
        {
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Genre genre = repository.Genres().Include(a => a.SongGenres)
                                            .ThenInclude(c => c.Song).Single(d => d.GenreID == id);

            //Album album = repository.Albums().Single(a => a.AlbumID == id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("GenreID, Name")] Genre genre)
        {

            if (id != genre.GenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    repository.UpdateGenre(genre);

                    await repository.SaveContextAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    {

                        throw;
                    }
                }
            }
            return View(genre);
        }
    }
}
