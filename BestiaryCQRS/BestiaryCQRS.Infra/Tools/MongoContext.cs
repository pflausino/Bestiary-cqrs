using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace BestiaryCQRS.Infra.Tools
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commmands;
        private readonly IConfiguration _configuration;
        public MongoContext(IConfiguration configuration)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            RegisterConventions();
            _commmands = new List<Func<Task>>();

            MongoClient = new MongoClient(Environment.GetEnvironmentVariable("MONGOCONNECTION") ?? configuration.GetSection("MongoSettings").GetSection("Connection").Value);

            Database = MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DATABASENAME") ?? configuration.GetSection("MongoSettings").GetSection("DatabaseName").Value);

        }

        public void AddCommand(Func<Task> func)
        {
            _commmands.Add(func);
        }

        public void Dispose()
        {
            while (Session != null && Session.IsInTransaction)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public async Task<int> SaveChanges()
        {
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();
                var commandTasks = _commmands.Select(c => c());

                await Task.WhenAll(commandTasks);
                await Session.CommitTransactionAsync();

            }
            return _commmands.Count();
        }
        private void RegisterConventions()
        {
            var pack = new ConventionPack
        {
            new IgnoreExtraElementsConvention(true),
            new IgnoreIfDefaultConvention(true)
        };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}