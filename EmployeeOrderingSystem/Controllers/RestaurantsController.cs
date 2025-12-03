using EmployeeOrderingSystem.Models;
using EmployeeOrderingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeOrderingSystem.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // List all restaurants
        public async Task<IActionResult> Index()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return View(restaurants);
        }

        // Show create restaurant form
        public IActionResult Create()
        {
            return View();
        }

        // Create new restaurant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LocationDescription,ContactNumber")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                await _restaurantService.CreateRestaurantAsync(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // Show menu management page for a restaurant
        public async Task<IActionResult> ManageMenu(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            ViewBag.RestaurantId = id;
            ViewBag.RestaurantName = restaurant.Name;
            var menuItems = await _restaurantService.GetMenuItemsByRestaurantIdAsync(id);

            return View(menuItems);
        }

        // Show form to add a new menu item
        public IActionResult AddMenuItem(int restaurantId)
        {
            ViewBag.RestaurantId = restaurantId;
            return View();
        }

        // Create a new menu item for a restaurant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMenuItem([Bind("RestaurantId,Name,Description,Price")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                await _restaurantService.CreateMenuItemAsync(menuItem);
                return RedirectToAction("ManageMenu", new { id = menuItem.RestaurantId });
            }
            ViewBag.RestaurantId = menuItem.RestaurantId;
            return View(menuItem);
        }
    }
}
