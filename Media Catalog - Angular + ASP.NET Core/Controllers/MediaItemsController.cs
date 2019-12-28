using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Media_Catalog.Database;
using Media_Catalog.Models;
using Media_Catalog.ViewModels;
using AutoMapper;
using Media_Catalog.Services;
using Media_Catalog.ResourceParameters;
using System.Text.Json;
using System.Globalization;

namespace Media_Catalog.Controllers
{
    [Route("api/mediaItems")]
    [ApiController]
    public class MediaItemsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAppDbRepository _appDbRepository;

        public MediaItemsController(AppDbContext context, IMapper mapper, IAppDbRepository appDbRepository)
        {
            _context = context;
            _mapper = mapper;
            _appDbRepository = appDbRepository;
        }

        // GET: api/mediaItems
        [HttpGet]
        public ActionResult<IEnumerable<MediaItemVM>> GetMediaItems()
        {

            var mediaItems = _appDbRepository.GetAllMediaItems();

            return Ok(_mapper.Map<IEnumerable<MediaItemVM>>(mediaItems));
        }

        // GET: api/mediaItems/5
        [HttpGet("{mediaItemsId}", Name = "GetMediaItem")]
        public async Task<IActionResult> GetMediaItemAsync(int mediaItemsId)
        {
            MediaItem mediaItem = await _context.MediaItems.Include("Genre")
                .Include("Publisher")
                .Include("Country")
                .Include("Artist")
               .FirstOrDefaultAsync(i=> i.Id == mediaItemsId);

            if (mediaItem == null)
            {
                return NotFound();
            }

            return Ok(new MediaItemVM()
            {
                Artist = mediaItem.Artist.FirstName + " " + mediaItem.Artist.LastName,
                Country = mediaItem.Country.Name,
                Genre = mediaItem.Genre.Name,
                Publisher = mediaItem.Publisher.Name,
                PublishingDate = mediaItem.PublishingDate,
                Title = mediaItem.Title
            });
        }

        //PUT: api/mediaItems/5
        [HttpPut("{mediaItemsId}")]
        public ActionResult UpdateMediaItem(int mediaItemsId, MediaItemForUpdateVM mediaItem)
        {
            if (!_appDbRepository.MediaItemExists(mediaItemsId))
            {
                return NotFound();
            }

            if (!_appDbRepository.ParametersExistPut(mediaItem))
            {
                return NotFound();
            }

            var mediaItemFromRepo = _appDbRepository.Find(mediaItemsId);

            _mapper.Map(mediaItem, mediaItemFromRepo);

            _appDbRepository.UpdateMediaItems(mediaItemFromRepo);

            _appDbRepository.Save();

            return NoContent();
        }

        // POST: api/mediaItems
        [HttpPost]
        public ActionResult<MediaItemVM> CreateMediaItem(MediaItemForCreationVM mediaItem)
        {
            if (!_appDbRepository.ParametersExistPost(mediaItem))
            {
                return NotFound();
            }
            var mediaItemEntity = new MediaItem()
            {
                ArtistID = mediaItem.ArtistID,
                CountryID = mediaItem.CountryID,
                PublisherID = mediaItem.PublisherID,
                GenreID = mediaItem.GenreID,
                PublishingDate = DateTime.Parse(mediaItem.PublishingDate),
                Title = mediaItem.Title
            };

            _appDbRepository.AddMediaItem(mediaItemEntity);
            _appDbRepository.Save();

            MediaItemVM mediaItemReturn = _mapper.Map<MediaItemVM>(mediaItemEntity);

          return RedirectToAction("GetMediaItem", new { mediaItemsId = mediaItemEntity.Id });

        }


        [HttpOptions]
        public IActionResult GetMediaItemsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        // DELETE: api/mediaItems/5
        [HttpDelete("{mediaItemsId}")]
        public ActionResult DeleteMediaItem(int mediaItemsId)
        {
            if (!_appDbRepository.MediaItemExists(mediaItemsId))
            {
                return NotFound();
            }

            var mediaItemFromRepo = _appDbRepository.Find(mediaItemsId);

            _appDbRepository.DeleteMediaItem(mediaItemFromRepo);
            _appDbRepository.Save();

            return NoContent();
        }

        private bool MediaItemExists(int id)
        {
            return _context.MediaItems.Any(e => e.Id == id);
        }
    }
}
