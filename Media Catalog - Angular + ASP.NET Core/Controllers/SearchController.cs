using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Media_Catalog.ResourceParameters;
using Media_Catalog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Media_Catalog.Services;
using Media_Catalog.Database;
using AutoMapper;

namespace Media_Catalog.Controllers
{
    [Route("api/mediaItems/search")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly IAppDbRepository _appDbRepository;
        private readonly IMapper _mapper;

        public SearchController(IMapper mapper, IAppDbRepository appDbRepository)
        {
            _mapper = mapper;
            _appDbRepository = appDbRepository;
        }
        [HttpPost]
        public ActionResult<IEnumerable<MediaItemVM>> GetSearchedMediaItems(
            MediaItemResourceParameters mediaItemResourceParameters)
        {

            var mediaItems = _appDbRepository.GetMediaItems(mediaItemResourceParameters);

            return Ok(_mapper.Map<IEnumerable<MediaItemVM>>(mediaItems));
        }

    }
}