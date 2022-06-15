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
    public class SaladService
    {
        private readonly IMongoCollection<Salad> _salads;

        public SaladService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _salads = mongoClient
                .GetDatabase(options.Value.DatabaseName)
                .GetCollection<Salad>("salads");
        }

        public async Task<List<Salad>> GetAll() =>
            await _salads.Find(_ => true).ToListAsync();

        public async Task<Salad> Get(string id) =>
            await _salads.Find(s => s._id == id).FirstOrDefaultAsync();

        public async Task Create(Salad grocery) =>
            await _salads.InsertOneAsync(grocery);

        public async Task Update(string id, Salad grocery) =>
            await _salads.ReplaceOneAsync(s => s._id == id, grocery);

        public async Task Delete(string id) =>
            await _salads.DeleteOneAsync(s => s._id == id);

    }

}
