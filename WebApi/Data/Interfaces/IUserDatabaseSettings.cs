namespace WebApi.Data
{
  public interface IUserDatabaseSettings
  {
    string UserCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}
