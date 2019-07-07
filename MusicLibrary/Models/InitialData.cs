using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace MusicLibrary.Models
{
    public class InitialData
    {
        public static void EnusrePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Songs.Any())
            {
                context.Songs.AddRange(
                    new Song { Title = "Rock", Artist = "The Rockers" },
                    new Song { Title = "Rocking", Artist = "The Rockers" },
                    new Song { Title = "Rocked", Artist = "The Rockers" },
                    new Song { Title = "RockSong4", Artist = "The Rockers" },
                    new Song { Title = "Punk", Artist = "The Punks" },
                    new Song { Title = "Punkiest", Artist = "The Punks" },
                    new Song { Title = "Punking", Artist = "The Punks" },
                    new Song { Title = "Punked", Artist = "The Punks" },
                    new Song { Title = "Slim shady", Artist = "Eminem" },
                    new Song { Title = "Beautiful", Artist = "Eminem" },
                    new Song { Title = "Rap God", Artist = "Eminem" },
                    new Song { Title = "Bohemian Rap Sody", Artist = "Eminem" },
                    new Song { Title = "Worldwide choppers", Artist = "Tech9" },
                    new Song { Title = "Speedom", Artist = "Tech9" },
                    new Song { Title = "Why Me", Artist = "Krizz Kaliko" },
                    new Song { Title = "Stop the world", Artist = "Krizz Kaliko" },
                    new Song { Title = "Chandelier", Artist = "Sia" },
                    new Song { Title = "Breathe Me", Artist = "Sia" },
                    new Song { Title = "Survive", Artist = "Sia" },
                    new Song { Title = "PopSong4", Artist = "Sia" },
                    new Song { Title = "Bang Bang", Artist = "Ariana Grande" },
                    new Song { Title = "Your gf", Artist = "Ariana Grande" },
                    new Song { Title = "Pop Queen", Artist = "Ariana Grande" },
                    new Song { Title = "Pop Singer", Artist = "Ariana Grande" },
                    new Song { Title = "Skater boi", Artist = "Avril" },
                    new Song { Title = "PopRocker", Artist = "Avril" },
                    new Song { Title = "With you", Artist = "Avril" },
                    new Song { Title = "Pop Rocking", Artist = "Avril" },
                    new Song { Title = "Time of your Life", Artist = "Green Day" },
                    new Song { Title = "American Idiot", Artist = "Green Day" },
                    new Song { Title = "Boulevard of broken dreams", Artist = "Green Day" },
                    new Song { Title = "Jesus of Suburbia", Artist = "Green Day" }

                );
                context.SaveChanges();
            }

            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                    new Genre { Name = "Rock" },
                    new Genre { Name = "Punk" },
                    new Genre { Name = "Rap" },
                    new Genre { Name = "Pop" },
                    new Genre { Name = "Pop Rock" },
                    new Genre { Name = "Punk Rock" }
                );
                context.SaveChanges();

            }

            if (!context.Albums.Any())
            {
                context.Albums.AddRange(
                    new Album { Name = "The Rocker's Greatest" },
                    new Album { Name = "Punk Rocker" },
                    new Album { Name = "World of Punk" },
                    new Album { Name = "Rap Album vol1" },
                    new Album { Name = "Pop Music" },
                    new Album { Name = "American Idiot" },
                    new Album { Name = "Avril Lavigne Album" },
                    new Album { Name = "World of Rock" },
                    new Album { Name = "Eminem Vol1" },
                    new Album { Name = "Strange Music" }

                );
                context.SaveChanges();

            }

            if (!context.SongAlbums.Any())
            {

                List<Song> AvrilSongs = context.Songs.Where(c => c.Artist.Equals("Avril")).ToList();
                List<Album> AvrilAlbums = context.Albums.Where(d => d.Name.Equals("Avril Lavigne Album")).ToList();

                List<Song> EminemSongs = context.Songs.Where(c => c.Artist.Equals("Eminem")).ToList();
                List<Album> EminemAlbums = context.Albums.Where(d => d.Name.Equals("Eminem Vol1") 
                                                                || d.Name.Equals("Rap Album vol1")).ToList();

                List<Song> RapSongs = context.Songs.Where(c => c.Artist.Equals("Krizz Kaliko") 
                                                          || c.Artist.Equals("Tech9")).ToList();
                List<Album> RapAlbums = context.Albums.Where(d => d.Name.Equals("Strange Music") 
                                                             || d.Name.Equals("Rap Album vol1")).ToList();

                List<Song> PopSongs = context.Songs.Where(c => c.Artist.Equals("Ariana Grande") 
                                                            || c.Artist.Equals("Sia")).ToList();
                List<Album> PopAlbums = context.Albums.Where(d => d.Name.Equals("Pop Music")).ToList();

                List<Song> GreenSongs = context.Songs.Where(c => c.Artist.Equals("Green Day")).ToList(); 
                List<Album> GreenAlbums = context.Albums.Where(d => d.Name.Equals("American Idiot") 
                                                                || d.Name.Equals("World of Punk") 
                                                                || d.Name.Equals("Punk Rocker")).ToList();

                List<Song> PunkSongs = context.Songs.Where(c => c.Artist.Equals("The Punks")).ToList();
                List<Album> PunkAlbums = context.Albums.Where(d => d.Name.Equals("World of Punk") 
                                                             || d.Name.Equals("Punk Rocker")).ToList();

                List<Song> RockSongs = context.Songs.Where(c => c.Artist.Equals("The Punks") 
                                                            || c.Artist.Equals("The Rockers")
                                                            || c.Artist.Equals("Avril")).ToList();
                List<Album> RockAlbums = context.Albums.Where(d => d.Name.Equals("World of Rock")
                                                            || d.Name.Equals("Punk Rocker")).ToList();

                List<Song> RockerSongs = context.Songs.Where(c => c.Artist.Equals("The Rockers")).ToList();
                List<Album> RockerAlbums = context.Albums.Where(d => d.Name.Equals("The Rocker's Greatest")).ToList();

                foreach (Song song in AvrilSongs) { 
                    foreach (Album album in AvrilAlbums) {
                        context.SongAlbums.Add(
                        new SongAlbum { SongID = song.SongID, AlbumID = album.AlbumID}
                        );
                    }
                }

                foreach (Song song in EminemSongs)
                {
                    foreach (Album album in EminemAlbums)
                    {
                        context.SongAlbums.Add(
                        new SongAlbum { SongID = song.SongID, AlbumID = album.AlbumID }
                        );

                    }
                }

                foreach (Song song in RapSongs)
                {
                    foreach (Album album in RapAlbums)
                    {
                        context.SongAlbums.Add(
                        new SongAlbum { SongID = song.SongID, AlbumID = album.AlbumID }
                        );
                    }
                }

                foreach (Song song in PopSongs)
                {
                    foreach (Album album in PopAlbums)
                    {
                        context.SongAlbums.Add(
                        new SongAlbum { SongID = song.SongID, AlbumID = album.AlbumID }
                        );
                    }
                }
                foreach (Song song in GreenSongs)
                {
                    foreach (Album album in GreenAlbums)
                    {
                        context.SongAlbums.Add(
                        new SongAlbum { SongID = song.SongID, AlbumID = album.AlbumID }
                        );
                    }
                }

                foreach (Song song in PunkSongs)
                {
                    foreach (Album album in PunkAlbums)
                    {
                        context.SongAlbums.Add(
                        new SongAlbum { SongID = song.SongID, AlbumID = album.AlbumID }
                        );
                    }
                }

                foreach (Song song in RockSongs)
                {
                    foreach (Album album in RockAlbums)
                    {
                        context.SongAlbums.Add(
                        new SongAlbum { SongID = song.SongID, AlbumID = album.AlbumID }
                        );
                    }
                }
                foreach (Song song in RockerSongs)
                {
                    foreach (Album album in RockerAlbums)
                    {
                        context.SongAlbums.Add(
                        new SongAlbum { SongID = song.SongID, AlbumID = album.AlbumID }
                        );
                    }
                }
                context.SaveChanges();
            }


            //new Genre { Name = "Rock" },
            //        new Genre { Name = "Punk" },
            //        new Genre { Name = "Rap" },
            //        new Genre { Name = "Pop" },
            //        new Genre { Name = "Pop Rock" },
            //        new Genre { Name = "Punk Rock" }

            if (!context.SongGenres.Any())
            {
                List<Song> PopRockSongs = context.Songs.Where(c => c.Artist.Equals("Avril")).ToList();
                List<Genre> PopRock = context.Genres.Where(d => d.Name.Equals("Pop Rock")).ToList();

                List<Song> RapSongs = context.Songs.Where(c => c.Artist.Equals("Krizz Kaliko")
                                                          || c.Artist.Equals("Tech9") || c.Artist.Equals("Eminem")).ToList();
                List<Genre> Rap = context.Genres.Where(d => d.Name.Equals("Rap")).ToList();

                List<Song> PopSongs = context.Songs.Where(c => c.Artist.Equals("Ariana Grande")
                                                            || c.Artist.Equals("Sia")
                                                            || c.Artist.Equals("Avril")).ToList();
                List<Genre> Pop = context.Genres.Where(d => d.Name.Equals("Pop")).ToList();

                List<Song> PunkRockSongs = context.Songs.Where(c => c.Artist.Equals("Green Day")).ToList();
                List<Genre> PunkRock = context.Genres.Where(d => d.Name.Equals("Punk Rock")).ToList();

                List<Song> PunkSongs = context.Songs.Where(c => c.Artist.Equals("The Punks") 
                                                            || c.Artist.Equals("Green Day")).ToList();
                List<Genre> Punk = context.Genres.Where(d => d.Name.Equals("Punk")).ToList();

                List<Song> RockSongs = context.Songs.Where(c => c.Artist.Equals("The Punks")
                                                            || c.Artist.Equals("Green Day")
                                                            || c.Artist.Equals("The Rockers")
                                                            || c.Artist.Equals("Avril")).ToList();
                List<Genre> Rock = context.Genres.Where(d => d.Name.Equals("Rock")).ToList();

                foreach (Song song in PopRockSongs)
                {
                    foreach (Genre genre in PopRock)
                    {
                        context.SongGenres.Add(
                        new SongGenre { SongID = song.SongID, GenreID = genre.GenreID }
                        );
                    }
                }

                foreach (Song song in PopSongs)
                {
                    foreach (Genre genre in Pop)
                    {
                        context.SongGenres.Add(
                        new SongGenre { SongID = song.SongID, GenreID = genre.GenreID }
                        );
                    }
                }

                foreach (Song song in RapSongs)
                {
                    foreach (Genre genre in Rap)
                    {
                        context.SongGenres.Add(
                        new SongGenre { SongID = song.SongID, GenreID = genre.GenreID }
                        );
                    }
                }

                foreach (Song song in PunkRockSongs)
                {
                    foreach (Genre genre in PunkRock)
                    {
                        context.SongGenres.Add(
                        new SongGenre { SongID = song.SongID, GenreID = genre.GenreID }
                        );
                    }
                }

                foreach (Song song in PunkSongs)
                {
                    foreach (Genre genre in Punk)
                    {
                        context.SongGenres.Add(
                        new SongGenre { SongID = song.SongID, GenreID = genre.GenreID }
                        );
                    }
                }

                foreach (Song song in RockSongs)
                {
                    foreach (Genre genre in Rock)
                    {
                        context.SongGenres.Add(
                        new SongGenre { SongID = song.SongID, GenreID = genre.GenreID }
                        );
                    }
                }

                context.SaveChanges();

            }

        }
    }
}
