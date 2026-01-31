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
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("PasswordManagerDB");
            _collection = database.GetCollection<PasswordEntry>("Passwords");

            Console.WriteLine("Connected to MongoDB");
        }

        // CREATE
        public void Add(PasswordEntry entry)
        {
            _collection.InsertOne(entry);
            Console.WriteLine("Saved to MongoDB");
        }

        // READ
        public List<PasswordEntry> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        // DELETE
        public void DeleteById(string id)
        {
            var result = _collection.DeleteOne(e => e.Id == id);

            if (result.DeletedCount > 0)
                Console.WriteLine("🗑️ Deleted successfully");
            else
                Console.WriteLine("⚠️ No entry found with that ID");
        }
    }
}
