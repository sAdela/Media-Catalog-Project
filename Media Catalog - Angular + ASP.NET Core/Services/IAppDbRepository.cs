using Media_Catalog.Models;
using Media_Catalog.ResourceParameters;
using Media_Catalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Catalog.Services
{
    public interface IAppDbRepository
    {
        IEnumerable<MediaItem> GetMediaItems(MediaItemResourceParameters mediaItemResourceParameters);
        IQueryable<MediaItem> GetAllMediaItems();
        void AddMediaItem(MediaItem mediaItem);
        bool Save();
        bool MediaItemExists(int id);
        MediaItem Find(int mediaItemsId);
        void UpdateMediaItems(MediaItem mediaItem);
        bool ParametersExistPut(MediaItemForUpdateVM mediaItem);
        bool ParametersExistPost(MediaItemForCreationVM mediaItem);
        void DeleteMediaItem(MediaItem mediaItem);


    }
}
