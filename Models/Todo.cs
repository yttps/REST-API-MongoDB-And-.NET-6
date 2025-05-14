using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoAPI.Models
{
    public class Todo
    {
        [BsonId] //pri key
        [BsonRepresentation(BsonType.ObjectId)] //ให้ MongoDB แปลงเป็น ObjectId อัตโนมัติ
        public string? Id { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("isComplete")]
        public bool IsComplete { get; set; }
    }
}