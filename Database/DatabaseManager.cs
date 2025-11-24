using InventoryTracker.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Database
{
    public class DatabaseManager
    {
        private string connectionString;


        public DatabaseManager(DatabaseSettings settings)
        {
            connectionString = $"Server={settings.Server};Database={settings.Database};User={settings.Username};Password={settings.Password};";
        }

        public MySqlConnection getConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public void createItemsTable()
        {
            using var connection = getConnection();
            connection.Open();

            string sql = @"CREATE TABLE IF NOT EXISTS InventoryTracker_Items 
                (
                SKUID INT AUTO_INCREMENT PRIMARY KEY,
                ItemName VARCHAR(255) NOT NULL,
                Description VARCHAR(255) NOT NULL,
                Quantity INT NOT NULL,
                Category VARCHAR(255) NOT NULL,
                LastUpdated DATETIME NOT NULL
                );
            ";

            using var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public void updateQuantity(int sku, int newValue)
        {
            using var connection = getConnection();
            connection.Open();

            string sql = "UPDATE inventorytracker_items SET Quantity = @Quantity WHERE SKUID = @SKUId";
            using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Quantity", newValue);
            cmd.Parameters.AddWithValue("SKUId", sku);
            cmd.ExecuteNonQuery();
        }

        public List<Item> getAllItems()
        {
            using var connection = getConnection();
            connection.Open();

            string sql = "SELECT * FROM inventorytracker_items";

            var items = new List<Item>();

            using var cmd = new MySqlCommand(sql, connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var item = new Item
                {
                    skuID = reader.GetInt32("SKUID"),
                    ItemName = reader.GetString("ItemName"),
                    Quantity = reader.GetInt32("Quantity"),
                    Category = reader.GetString("Category"),
                    LastUpdated = reader.GetDateTime("LastUpdated")
                };

                items.Add(item);
            }
            return items;
        }

        public int addItem(Item item)
        {
            using var connection = getConnection();
            connection.Open();

            string sql = "INSERT INTO inventoryTracker_items (ItemName, Description, Quantity, Category, LastUpdated) VALUES (@ItemName, @Description, @Quantity, @Category, @LastUpdated); SELECT LAST_INSERT_ID();";
            MySqlCommand cmd = new MySqlCommand(sql,connection);
            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@Description", item.itemDescription);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
            cmd.Parameters.AddWithValue("@Category", item.Category);
            cmd.Parameters.AddWithValue("@LastUpdated", item.LastUpdated);

            int skuId = Convert.ToInt32(cmd.ExecuteScalar());
            return skuId;

        }

    }
}
