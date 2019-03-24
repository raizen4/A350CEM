using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Aircraft
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("FlyingHours")]
        public string FlyingHours { get; set; }

        [BsonElement("Team")]
        public Team Team { get; set; }

        [BsonElement("Tasks")]
        public List<TaskClass> Tasks { get; set; }

    }
}
