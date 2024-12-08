using GesFin.Core.Models;
using GesFin.Core.Requests.Categories;
using GesFin.Core.Responses;

namespace GesFin.Core.Handles
{
    public interface ICategoryHandler
    {
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
        Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
        Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
        Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
        Task<PagedResponse<List<Category>>> GetByAllAsync(GetAllCategoriesRequest request);

    }
}