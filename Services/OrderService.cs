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
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _orders = mongoClient
                .GetDatabase(options.Value.DatabaseName)
                .GetCollection<Order>("orders");
        }

        public async Task<List<Order>> GetAll() =>
            await _orders.Find(_ => true).ToListAsync();

        public async Task<Order> Get(string id) =>
            await _orders.Find(s => s._id == id).FirstOrDefaultAsync();

        public async Task Create(Order grocery) =>
            await _orders.InsertOneAsync(grocery);

        public async Task Update(string id, Order grocery) =>
            await _orders.ReplaceOneAsync(s => s._id == id, grocery);

        public async Task Delete(string id) =>
            await _orders.DeleteOneAsync(s => s._id == id);

    }

}
