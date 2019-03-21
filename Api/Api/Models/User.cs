using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

       
        public string Token { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
