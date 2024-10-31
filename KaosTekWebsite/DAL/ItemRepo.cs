using KaosTekWebsite.Models;
using MySql.Data.MySqlClient;


namespace KaosTekWebsite.DAL
{
    
    public class ItemRepo
    {
        private readonly string _connectionString;

        public ItemRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM item", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Item item = new Item();
                        {
                            item.itemID = reader.GetInt32("itemID");
                            item.itemName = reader.GetString("itemName");
                            item.price = reader.GetInt32("price");
                        }
                        items.Add(item);
                    }
                }
            }
            return items;

        }
    }
}
