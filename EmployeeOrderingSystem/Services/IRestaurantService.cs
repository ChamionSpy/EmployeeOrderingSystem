using EmployeeOrderingSystem.Models;

namespace EmployeeOrderingSystem.Services
{
    // Interface defining CRUD operations for Restaurants and their MenuItems
    public interface IRestaurantService
    {
        // Restaurant operations
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant?> GetRestaurantByIdAsync(int id);
        Task CreateRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(int id);

        // MenuItem operations
        Task<List<MenuItem>> GetMenuItemsByRestaurantIdAsync(int restaurantId);
        Task<MenuItem?> GetMenuItemByIdAsync(int id);
        Task CreateMenuItemAsync(MenuItem menuItem);
        Task UpdateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(int id);
    }
}
