using MongoDB.Driver;

namespace Books.Api.Infrastructure
{
    public class MongoFactory
    {
        private readonly IBookstoreDatabaseSettings _bookstoreDatabaseSettings;

        public MongoFactory(IBookstoreDatabaseSettings bookstoreDatabaseSettings)
        {
            _bookstoreDatabaseSettings = bookstoreDatabaseSettings;
        }

        public MongoClient MongoClient => new MongoClient(_bookstoreDatabaseSettings.ConnectionString);
        public IMongoDatabase Database => MongoClient.GetDatabase(_bookstoreDatabaseSettings.DatabaseName);
    }
}