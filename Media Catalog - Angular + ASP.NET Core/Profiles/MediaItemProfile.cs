using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Media_Catalog.Profiles
{
    public class MediaItemProfile : Profile
    {
        public MediaItemProfile()
        {
            CreateMap<Models.MediaItem, ViewModels.MediaItemVM>()
                .ForMember(
                    dest => dest.Publisher,
                    opt => opt.MapFrom(src => src.Publisher.Name)
                )
                .ForMember(
                    dest => dest.Artist,
                    opt => opt.MapFrom(src => $"{src.Artist.FirstName} {src.Artist.LastName}")
                )
                .ForMember(
                    dest => dest.Country,
                    opt => opt.MapFrom(src => src.Country.Name)
                )
                .ForMember(
                    dest => dest.Genre,
                    opt => opt.MapFrom(src => src.Genre.Name)
                );

            CreateMap<ViewModels.MediaItemForCreationVM, Models.MediaItem>();

            CreateMap<ViewModels.MediaItemForUpdateVM, Models.MediaItem>();
                
                
        }
    }
}
