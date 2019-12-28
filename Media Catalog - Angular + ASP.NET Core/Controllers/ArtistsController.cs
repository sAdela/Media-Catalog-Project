using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Media_Catalog.Database;
using Media_Catalog.Models;
using AutoMapper;
using Media_Catalog.ViewModels;

namespace Media_Catalog.Controllers
{
    [Route("api/mediaItems/{mediaItemId}/artist")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ArtistsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        [HttpGet()]
        public async Task<ActionResult<ArtistVM>> GetArtistForMediaItem(int mediaItemId)
        {
            var mediaItem = await _context.MediaItems.FindAsync(mediaItemId);

            var artist = _context.Artists.Where(i => i.Id == mediaItem.ArtistID).FirstOrDefault();

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ArtistVM>(artist));
        }

       
    }
}
