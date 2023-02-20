using LojaDiversidade.Web.Models;

namespace LojaDiversidade.Web.Services.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllCategories(string token);
}
