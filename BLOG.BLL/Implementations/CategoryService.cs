/*using AutoMapper;
using BLOG.BLL.Interfaces;
using BLOG.BLL.Models;
using BLOG.DAL.Entity;
using BLOG.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAllCategories();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return categoryDtos;
        }

        public CategoryViewModel GetCategoryById(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetCategoryById(id);
            var categoryDto = _mapper.Map<CategoryViewModel>(category);
            return categoryDto;
        }

        public async Task AddCategory(CategoryViewModel category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _unitOfWork.CategoryRepository.AddCategory(categoryEntity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCategory(CategoryViewModel category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _unitOfWork.CategoryRepository.UpdateCategory(categoryEntity);
            await _unitOfWork.CommitAsync(); 
        }

        public async Task DeleteCategory(int id)
        {
            _unitOfWork.CategoryRepository.DeleteCategory(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
*/