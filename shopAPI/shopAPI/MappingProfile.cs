using System.Runtime.InteropServices;
using AutoMapper;
using ShopApi.Models.ApiModels;
using ShopApi.Models.Entities;

namespace ShopApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryModel>();

        }

    }
}
