using IFood.Cliente.Domain.Cliente;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IFood.Cliente.Repository
{
    public class MongoContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;
        public IConfigurationRoot Configuration { get; }

        public MongoContext()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            mongoClient = new MongoClient(Configuration["MongoDB:ConnectionString"]);
            database = mongoClient.GetDatabase(Configuration["MongoDB:Database"]);
        }

        public IMongoCollection<ClienteModel> Cliente
        {
            get
            {
                return database.GetCollection<ClienteModel>("Cliente");
            }
        }
    }
}
