using MongoDB.Driver;
using PasswordManager.Models;
using System;
using System.Collections.Generic;

namespace PasswordManager.Data
{
    public class PasswordRepository
    {
        private readonly IMongoCollection<PasswordEntry> _collection;

        public PasswordRepository()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("PasswordManagerDB");
                _collection = database.GetCollection<PasswordEntry>("Passwords");

                Console.WriteLine("✅ Connected to MongoDB");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ MongoDB connection failed: " + ex.Message);
            }
        }

        public void Add(PasswordEntry entry)
        {
            _collection.InsertOne(entry);
            Console.WriteLine("✅ Inserted into MongoDB");
        }

        public List<PasswordEntry> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }
    }
}
