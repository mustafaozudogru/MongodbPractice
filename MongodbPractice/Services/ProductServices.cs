using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongodbPractice.Infustracture;
using MongodbPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongodbPractice.Services
{
    public class ProductServices : IProductServices
    {
        private readonly MainContext _context;
        public ProductServices(IOptions<DbSettings> settings)
        {
            _context = new MainContext(settings);
        }

        public async Task<Products> GetAsync(string id)
        {
            var collection = await _context.Products.FindAsync(x => x.id == id).ConfigureAwait(false);

            return collection.FirstOrDefault();
        }

        public async Task<Products> CreateAsync(Products product)
        {
            await _context.Products.InsertOneAsync(product).ConfigureAwait(false);

            return product;
        }

        public async Task<Products> UpdateAsync(Products product)
        {
            await _context.Products.ReplaceOneAsync(x => x.id == product.id, product).ConfigureAwait(false);

            return product;
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            var list = await _context.Products.Find(x => true).ToListAsync();

            return list;
        }

        public async Task DeleteAsync(string id)
        {
            await _context.Products.DeleteOneAsync(
                Builders<Products>.Filter.Eq("Id", id)).ConfigureAwait(false);
        }
    }
}
