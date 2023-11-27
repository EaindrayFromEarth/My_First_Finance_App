using My_First_Finance_App.Models;

namespace My_First_Finance_App.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        void UpdateCategory(Category category);
    }
}