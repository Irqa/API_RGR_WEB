using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly GroceryService _restaurantService;
        private readonly SaladService _saladService;
        private readonly OrderService _orderService;
        private readonly OrderItemService _orderItemService;
        private readonly IngredientService _ingredientService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GroceryService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        [HttpGet("groceries/{id}")]
        public async Task<Grocery> GetOne(string id)
        {
            return await _restaurantService.Get(id);
        }

        [HttpGet("groceries")]
        public async Task<List<Grocery>> Get()
        {
            return await _restaurantService.GetAll();
        }
        
        [HttpPost("groceries")]
        public async Task<Grocery> PostGroceries([FromBody]Grocery grocery)
        {
            await _restaurantService.Create(grocery);
            return grocery;
        }

        [HttpGet("salads/{id}")]
        public async Task<Salad> GetSalad(string id)
        {
            return await _saladService.Get(id);
        }

        [HttpPost("salads")]
        public async Task<Salad> PostSalads([FromBody]Salad salad)
        {
            await _saladService.Create(salad);
            return salad;
        }


        [HttpGet("salads")]
        public async Task<List<Grocery>> GetSalads()
        {
            return await _restaurantService.GetAll();
        }


        [HttpPost("orders")]
        public async Task<Order> PostOrder([FromBody] Order order)
        {
            await _orderService.Create(order);
            return order;
        }
    }
}
