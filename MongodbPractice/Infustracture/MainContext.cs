using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongodbPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongodbPractice.Infustracture
{
    public class MainContext
    {
        private readonly IMongoDatabase _db = null;

        public MainContext(IOptions<DbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            if (client != null)
            {
                _db = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Products> Products
        {
            get
            {
                return _db.GetCollection<Products>("Products");
            }
        }
    }
}
