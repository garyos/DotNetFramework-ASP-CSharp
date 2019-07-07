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
    public class AlbumController : Controller
    {
        
        private IAlbumRepository repository;

        public AlbumController(IAlbumRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Albums());


        public ViewResult SongsByAlbum(int id)
        {
            var album = repository.Albums().Include(a => a.SongAlbums)
                                            .ThenInclude(c => c.Song).Where(d => d.AlbumID == id);

            return View(album);
        }

        [HttpPost]
        public ViewResult NewAlbum()
        {
            Album newAlb = new Album { Name = Request.Form["Name"] };
            repository.AddAlbum(newAlb);
            repository.SaveContext();
            return View();
        }
        
        public ViewResult AddAlbum()
        {
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Album album = repository.Albums().Include(a => a.SongAlbums)
                                            .ThenInclude(c => c.Song).Single(d => d.AlbumID == id);

            //Album album = repository.Albums().Single(a => a.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("AlbumID, Name")] Album album)
        {

            if (id != album.AlbumID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    repository.UpdateAlbum(album);

                    await repository.SaveContextAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    { 

                        throw;
                    }
                }
            }
            return View(album);
        }


    }
}
