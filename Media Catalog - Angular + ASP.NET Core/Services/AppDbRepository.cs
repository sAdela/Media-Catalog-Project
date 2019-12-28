using Media_Catalog.Database;
using Media_Catalog.Models;
using Media_Catalog.ResourceParameters;
using Media_Catalog.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Catalog.Services
{
    public class AppDbRepository : IAppDbRepository
    {
        private readonly AppDbContext _context;

        public AppDbRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        

        public void AddMediaItem(MediaItem mediaItem)
        {
            if (mediaItem == null)
            {
                throw new ArgumentNullException(nameof(mediaItem));
            }

            _context.MediaItems.Add(mediaItem);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


       public bool ParametersExistPut(MediaItemForUpdateVM mediaItem)
        {
            return (_context.Artists.Any(a => a.Id == mediaItem.ArtistID)) &&
                   _context.Genres.Any(g => g.Id == mediaItem.GenreID) &&
                   _context.Countries.Any(c => c.Id == mediaItem.CountryID) &&
                   _context.Publishers.Any(p => p.Id == mediaItem.PublisherID);
        }
        public bool ParametersExistPost(MediaItemForCreationVM mediaItem)
        {
            return (_context.Artists.Any(a => a.Id == mediaItem.ArtistID)) &&
                   _context.Genres.Any(g => g.Id == mediaItem.GenreID) &&
                   _context.Countries.Any(c => c.Id == mediaItem.CountryID) &&
                   _context.Publishers.Any(p => p.Id == mediaItem.PublisherID);
        }
        public bool MediaItemExists(int mediaItemsId)
       {
            return _context.MediaItems.Any(a => a.Id == mediaItemsId);
       }

        public void DeleteMediaItem(MediaItem mediaItem)
        {
            _context.MediaItems.Remove(mediaItem);
        }

        public IQueryable<MediaItem> GetAllMediaItems()
        {
            return _context.MediaItems.Include("Genre")
                    .Include("Publisher")
                    .Include("Country")
                    .Include("Artist");
        }

        public MediaItem Find(int mediaItemsId)
        {
            return GetAllMediaItems().Where(i => i.Id == mediaItemsId).FirstOrDefault();
        }
        private bool ParametersEmpty(MediaItemResourceParameters mediaItemResourceParameters)
        {
            return string.IsNullOrWhiteSpace(mediaItemResourceParameters.Artist)
                && string.IsNullOrWhiteSpace(mediaItemResourceParameters.SearchQuery)
                && string.IsNullOrWhiteSpace(mediaItemResourceParameters.Country)
                && string.IsNullOrWhiteSpace(mediaItemResourceParameters.Genre)
                && string.IsNullOrWhiteSpace(mediaItemResourceParameters.Publisher)
                && string.IsNullOrWhiteSpace(mediaItemResourceParameters.Title);
        }

        public IEnumerable<MediaItem> SearchedCollection(MediaItemResourceParameters mediaItemResourceParameters)
        {
            var collection = GetAllMediaItems();

            if (!string.IsNullOrWhiteSpace(mediaItemResourceParameters.Artist))
            {
                var artist = mediaItemResourceParameters.Artist.Trim();
                collection = collection.Where(a => a.Artist.FirstName + " " + a.Artist.LastName == artist);
            }

            if (!string.IsNullOrWhiteSpace(mediaItemResourceParameters.Genre))
            {
                var genre = mediaItemResourceParameters.Genre.Trim();
                collection = collection.Where(a => a.Genre.Name == genre);
            }

            if (!string.IsNullOrWhiteSpace(mediaItemResourceParameters.Publisher))
            {
                var publisher = mediaItemResourceParameters.Publisher.Trim();
                collection = collection.Where(a => a.Publisher.Name == publisher);
            }
            if (!string.IsNullOrWhiteSpace(mediaItemResourceParameters.Title))
            {
                var title = mediaItemResourceParameters.Title.Trim();
                collection = collection.Where(a => a.Title == title);
            }
            if (!string.IsNullOrWhiteSpace(mediaItemResourceParameters.Country))
            {
                var country = mediaItemResourceParameters.Country.Trim();
                collection = collection.Where(a => a.Country.Name == country);
            }

            return collection;
        }
        public IEnumerable<MediaItem> GetMediaItems(MediaItemResourceParameters mediaItemResourceParameters)
        {

            if (ParametersEmpty(mediaItemResourceParameters))
            {
                return GetAllMediaItems();
            }

            var collection = SearchedCollection(mediaItemResourceParameters);

            
            //ako searchQuery nije null, nastavi nad ovom dosad kolekcijom pretragu
            if (!string.IsNullOrWhiteSpace(mediaItemResourceParameters.SearchQuery))
             {
                var searchQuery = mediaItemResourceParameters.SearchQuery.Trim();
                if (searchQuery.Contains(" "))
                {
                    collection = collection.Where(a => a.Artist.FirstName.ToLower().Contains(searchQuery)
                    || a.Artist.LastName.ToLower().Contains(searchQuery)
                    || a.Artist.LastName.ToLower().Contains(searchQuery.Split(" ")[0])
                    || a.Artist.LastName.ToLower().Contains(searchQuery.Split(" ")[1])
                    || a.Artist.FirstName.ToLower().Contains(searchQuery.Split(" ")[0])
                    || a.Artist.FirstName.ToLower().Contains(searchQuery.Split(" ")[1])
                    || a.Title.ToLower().Contains(searchQuery)
                    || a.Title.ToLower().Contains(searchQuery.Split(" ")[0])
                    || a.Title.ToLower().Contains(searchQuery.Split(" ")[1])
                    || a.Publisher.Name.ToLower().Contains(searchQuery)
                    || a.Country.Name.ToLower().Contains(searchQuery)
                    || a.Genre.Name.ToLower().Contains(searchQuery));
                }
                else
                {
                    collection = collection.Where(a => a.Artist.FirstName.ToLower().Contains(searchQuery)
                    || a.Artist.LastName.ToLower().Contains(searchQuery)
                    || a.Title.ToLower().Contains(searchQuery)
                    || a.Country.Name.ToLower().Contains(searchQuery)
                    || a.Publisher.Name.ToLower().Contains(searchQuery)
                    || a.Genre.Name.ToLower().Contains(searchQuery));
                }
            }

            return collection;
          
        }
        public void UpdateMediaItems(MediaItem mediaItem)
        {
        }
    }
}
