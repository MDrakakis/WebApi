using MongoDB.Driver;
using WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data;

namespace WebApi.Services
{
  public class UserService
  {
    #region Setting

    private readonly IMongoCollection<User> _users;

    public UserService(IUserDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _users = database.GetCollection<User>(settings.UserCollectionName);
    }

    #endregion Setting

    #region Get

    public List<User> Get() =>
      _users.Find(users => true).ToList();

    public User Get(string id) =>
        _users.Find<User>(user => user.Id == id).FirstOrDefault();

    #endregion Get

    #region Create

    public User Create(User user)
    {
      _users.InsertOne(user);
      return user;
    }

    #endregion Create

    #region Update

    public void Update(string id, User userr)
    {
      _users.ReplaceOne(user => user.Id == id, userr);
    }

    #endregion Update

    #region Delete

    public void Remove(User userr) =>
      _users.DeleteOne(user => user.Id == userr.Id);

    public void Remove(string id) =>
      _users.DeleteOne(user => user.Id == id);

    #endregion Delete
  }
}
