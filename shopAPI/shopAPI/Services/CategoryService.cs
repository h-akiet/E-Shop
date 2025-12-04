using AutoMapper;
using ShopApi.Data.Repositories.Interfaces;
using ShopApi.Models.ApiModels;
using ShopApi.Models.Entities;
using ShopApi.Services.Interface;

namespace ShopApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void AddCategory(CategoryModel category)
        {
            _repository.AddCategory(_mapper.Map<Category>(category));

        }

        public List<CategoryModel> GetCategories()
        {
            return _repository.GetAll().Select(c => _mapper.Map<CategoryModel>(c)).ToList();
        }
        

        public CategoryModel? GetCategoryById(int id)
        {
            Category? result = _repository.GetCategoryById(id);
           
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<CategoryModel>(result);

        }

        public void UpdateCategory(CategoryModel category)
        {
            
            _repository.UpdateCategory(_mapper.Map<Category>(category));
        }

        public void DeleteCategory(int id)
        {
            Category? category = _repository.GetCategoryById(id);
            if (category != null)
            {
                _repository.DeleteCategory(category);
            }
        }
    }
}
