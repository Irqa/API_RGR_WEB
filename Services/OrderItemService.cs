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
    //public class OrderItemService
    //{
    //    private readonly IMongoCollection<OrderItem> _salads;

    //    public OrderItemService(IOptions<DatabaseSettings> options)
    //    {
    //        var mongoClient = new MongoClient(options.Value.ConnectionString);

    //        _salads = mongoClient
    //            .GetDatabase(options.Value.DatabaseName)
    //            .GetCollection<OrderItem>("orderitems");
    //    }

    //    public async Task<List<OrderItem>> GetAll() =>
    //        await _salads.Find(_ => true).ToListAsync();

    //    public async Task<OrderItem> Get(string id) =>
    //        await _salads.Find(s => s._id == id).FirstOrDefaultAsync();

    //    public async Task Create(OrderItem grocery) =>
    //        await _salads.InsertOneAsync(grocery);

    //    public async Task Update(string id, OrderItem grocery) =>
    //        await _salads.ReplaceOneAsync(s => s._id == id, grocery);

    //    public async Task Delete(string id) =>
    //        await _salads.DeleteOneAsync(s => s._id == id);

    //}

}
