using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace WebApi.Models
{
  public class User
  {
    [BsonId]
    [DataMember]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [DataMember]
    [BsonElement("name")]
    public string Name { get; set; }

    [DataMember]
    [BsonElement("lastName")]
    public string LastName { get; set; }

    [DataMember]
    [BsonElement("address")]
    public string Address { get; set; }

    [DataMember]
    [BsonElement("phone")]
    public string Phone { get; set; }

    [DataMember]
    [BsonElement("mobilePhone")]
    public string MobilePhone { get; set; }

    [DataMember]
    [BsonElement("email")]
    public string Email { get; set; }

    [DataMember]
    [BsonElement("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }
  }
}
