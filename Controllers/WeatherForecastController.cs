using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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
        //private readonly OrderItemService _orderItemService;
        private readonly IngredientService _ingredientService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , GroceryService restaurantService
            , SaladService saladService
            , OrderService orderService
            , IngredientService ingredientService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
            _saladService = saladService;
            _orderService = orderService;
            _ingredientService = ingredientService;
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
        public async Task<Salad> PostSalads([FromBody]SaladDto saladDto)
        {
            var salad = new Salad
            {
                Name = saladDto.Name,
                IsFromConstructor = saladDto.IsFromConstructor,
                Ingredients = saladDto.Ingredients
            };
            using(var ms = new MemoryStream())
            {
                saladDto.Image.CopyTo(ms);
                salad.Image = Convert.ToBase64String(ms.ToArray());
            }
            await _saladService.Create(salad);
            return salad;
        }


        [HttpGet("salads")]
        public async Task<List<Salad>> GetSalads()
        {
            return await _saladService.GetAll();
        }


        [HttpPost("orders")]
        public async Task<Order> PostOrder([FromBody] Order order)
        {
            await _orderService.Create(order);
            return order;
        }
    }
}
