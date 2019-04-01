using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Client.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
      

        [BsonElement("Name")]
        public string Name { get; set; }
       
        [BsonElement("Team")]
        public string Team { get; set; }

        [BsonElement("ManHours")]
        public string ManHours { get; set; }

        [BsonElement("Spec")]
        public string Spec {get;set;}
    }
}
