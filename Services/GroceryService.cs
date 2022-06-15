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
    public class GroceryService
    {
        private readonly IMongoCollection<Grocery> _groceries;

        public GroceryService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _groceries = mongoClient
                .GetDatabase(options.Value.DatabaseName)
                .GetCollection<Grocery>("groceries");
        }

        public async Task<List<Grocery>> GetAll() =>
            await _groceries.Find(_ => true).ToListAsync();

        public async Task<Grocery> Get(string id) =>
            await _groceries.Find(s => s._id == id).FirstOrDefaultAsync();

        public async Task Create(Grocery grocery) =>
            await _groceries.InsertOneAsync(grocery);

        public async Task Update(string id, Grocery grocery) =>
            await _groceries.ReplaceOneAsync(s => s._id == id, grocery);

        public async Task Delete(string id) =>
            await _groceries.DeleteOneAsync(s => s._id == id);

    }
}
