namespace ShopApi
{
    using AutoMapper;
    using ShopApi.Models.ApiModels;
    using ShopApi.Models.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
