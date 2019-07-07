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
    public class SongController : Controller
    {
        private ISongRepository repository;

        public SongController(ISongRepository repo)
        {
            repository = repo;



        }

        public ViewResult List()
        {
            var song = repository.Songs().Include(a => a.SongGenres)
                                            .ThenInclude(c => c.Genre)
                                        .Include(m => m.SongAlbums)
                                            .ThenInclude(t => t.Album);
            return View(song);
        }


        public ViewResult SongsByAlbum(String albumSelection) => View(repository.Songs().Where(b => b.SongAlbums.Where(
                                                                                             c => c.Album.Name.Equals(albumSelection)
                                                                                             ).Any()).ToList());


        [HttpPost]
        public ViewResult NewSong()
        {
            Song newSong = new Song { Title = Request.Form["Title"], Artist = Request.Form["Artist"] };
            repository.AddSong(newSong);
            repository.SaveContext();

            return View();
        }

        public ViewResult AddSong()
        {
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = repository.Songs().Include(a => a.SongGenres)
                                            .ThenInclude(c => c.Genre)
                                        .Include(m => m.SongAlbums)
                                            .ThenInclude(t => t.Album)
                .Single(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }
            PopulateAssignedAlbums(song);
            PopulateAssignedGenres(song);
            return View(song);
        }

        private void PopulateAssignedAlbums(Song song)
        {
            var allAlbums = repository.Albums();
            var SongAlbums = new HashSet<int>(song.SongAlbums.Select(a => a.AlbumID));
            var viewModel = new List<AssignedAlbum>();
            foreach (var album in allAlbums)
            {
                viewModel.Add(new AssignedAlbum
                {
                    AlbumID = album.AlbumID,
                    Name = album.Name,
                    Assigned = SongAlbums.Contains(album.AlbumID)
                });
            }
            ViewData["Albums"] = viewModel;
        }

        private void PopulateAssignedGenres(Song song)
        {
            var allGenres = repository.Genres();
            var SongGenres = new HashSet<int>(song.SongGenres.Select(g => g.GenreID));
            var viewModel = new List<AssignedGenre>();
            foreach (var genre in allGenres)
            {
                viewModel.Add(new AssignedGenre
                {
                    GenreID = genre.GenreID,
                    Name = genre.Name,
                    Assigned = SongGenres.Contains(genre.GenreID)
                });
            }
            ViewData["Genres"] = viewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedAlbums, string[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songToUpdate = repository.Songs().Include(a => a.SongGenres)
                                            .ThenInclude(c => c.Genre)
                                        .Include(m => m.SongAlbums)
                                            .ThenInclude(t => t.Album)
                .Single(m => m.SongID == id);

            if (await TryUpdateModelAsync<Song>(
                songToUpdate,
                "",
                i => i.Title, i => i.Artist))
            {
                UpdateSongAlbums(selectedAlbums, songToUpdate);
                UpdateSongGenres(selectedGenres, songToUpdate);
                try
                {
                    await repository.SaveContextAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            UpdateSongAlbums(selectedAlbums, songToUpdate);
            UpdateSongGenres(selectedGenres, songToUpdate);
            PopulateAssignedAlbums(songToUpdate);
            PopulateAssignedGenres(songToUpdate);
            repository.SaveContext();
            return View(songToUpdate);
        }

        private void UpdateSongAlbums(string[] selectedAlbums, Song songToUpdate)
        {
            if (selectedAlbums == null)
            {
                songToUpdate.SongAlbums = new List<SongAlbum>();
                return;
            }

            var selectedAlbumsHS = new HashSet<string>(selectedAlbums);
            var songAlbums = new HashSet<int>
                (songToUpdate.SongAlbums.Select(c => c.Album.AlbumID));
            foreach (var album in repository.Albums())
            {
                if (selectedAlbumsHS.Contains(album.AlbumID.ToString()))
                {
                    if (!songAlbums.Contains(album.AlbumID))
                    {
                        songToUpdate.SongAlbums.Add(new SongAlbum { SongID = songToUpdate.SongID, AlbumID = album.AlbumID });
                    }
                }
                else
                {

                    if (songAlbums.Contains(album.AlbumID))
                    {
                        SongAlbum SongAlbumToRemove = songToUpdate.SongAlbums.FirstOrDefault(i => i.AlbumID == album.AlbumID);
                        repository.DeleteSongAlbum(SongAlbumToRemove);
                    }
                }
            }
        }





        private void UpdateSongGenres(string[] selectedGenres, Song songToUpdate)
        {
            if (selectedGenres == null)
            {
                songToUpdate.SongGenres = new List<SongGenre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var songGenres = new HashSet<int>
                (songToUpdate.SongGenres.Select(c => c.Genre.GenreID));
            foreach (var genre in repository.Genres())
            {
                if (selectedGenresHS.Contains(genre.GenreID.ToString()))
                {
                    if (!songGenres.Contains(genre.GenreID))
                    {
                        songToUpdate.SongGenres.Add(new SongGenre { SongID = songToUpdate.SongID, GenreID = genre.GenreID });
                    }
                }
                else
                {

                    if (songGenres.Contains(genre.GenreID))
                    {
                        SongGenre SongGenreToRemove = songToUpdate.SongGenres.FirstOrDefault(i => i.GenreID == genre.GenreID);
                        repository.DeleteSongGenre(SongGenreToRemove);
                    }
                }
            }
        }
    }
}
