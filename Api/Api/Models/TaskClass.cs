using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Client.Models
{
    public class TaskClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("AircraftId")]
        public string AircraftId { get; set; }
    }
}
