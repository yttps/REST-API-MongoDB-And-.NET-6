using MongoDB.Driver;
using TodoAPI.Models;
using Microsoft.Extensions.Options;

namespace TodoAPI.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todoCollection;

        public TodoService(IOptions<TodoDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _todoCollection = database.GetCollection<Todo>(settings.Value.TodoCollectionName);
        }

        public async Task<List<Todo>> GetAsync() =>
            await _todoCollection.Find(_ => true).ToListAsync();

        public async Task<Todo?> GetAsync(string id) =>
            await _todoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Todo newTodo) =>
            await _todoCollection.InsertOneAsync(newTodo);

        public async Task UpdateAsync(string id, Todo updatedTodo) =>
            await _todoCollection.ReplaceOneAsync(x => x.Id == id, updatedTodo);

        public async Task RemoveAsync(string id) =>
            await _todoCollection.DeleteOneAsync(x => x.Id == id);
    }
}
