using MongodbPractice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongodbPractice.Services
{
    public interface IProductServices
    {
        Task<Products> GetAsync(string id);

        Task<Products> CreateAsync(Products product);

        Task<Products> UpdateAsync(Products product);

        Task<IEnumerable<Products>> GetAllAsync();

        Task DeleteAsync(string id);
    }
}
