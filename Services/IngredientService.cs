using API.Data;
using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class IngredientService
    {
        private readonly IMongoCollection<Ingredient> _ingredients;

        public IngredientService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _ingredients = mongoClient
                .GetDatabase(options.Value.DatabaseName)
                .GetCollection<Ingredient>("ingredients");
        }

        public async Task<List<Ingredient>> GetAll() =>
            await _ingredients.Find(_ => true).ToListAsync();

        public async Task<Ingredient> Get(string id) =>
            await _ingredients.Find(s => s._id == id).FirstOrDefaultAsync();

        public async Task Create(Ingredient ingredient) =>
            await _ingredients.InsertOneAsync(ingredient);

        public async Task Update(string id, Ingredient ingredient) =>
            await _ingredients.ReplaceOneAsync(s => s._id == id, ingredient);

        public async Task Delete(string id) =>
            await _ingredients.DeleteOneAsync(s => s._id == id);

    }


}
