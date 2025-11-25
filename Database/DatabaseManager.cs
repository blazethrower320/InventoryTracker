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

        public void createTables()
        {
            try
            {
                using var connection = getConnection();
                connection.Open();

                string sql1 = @"CREATE TABLE IF NOT EXISTS InventoryTracker_Items 
                (
                SKUID INT AUTO_INCREMENT PRIMARY KEY,
                ItemName VARCHAR(255) NOT NULL,
                Description VARCHAR(255) NOT NULL,
                Quantity INT NOT NULL,
                Category VARCHAR(255) NOT NULL,
                LastUpdated DATETIME NOT NULL
                );
            ";
                string sql2 = @"CREATE TABLE IF NOT EXISTS InventoryTracker_Category 
                (
                Id INT AUTO_INCREMENT PRIMARY KEY,
                CategoryType VARCHAR(255) NOT NULL,
                Description VARCHAR(255) NOT NULL,
                HexCode VARCHAR(100) NOT NULL
                );
            ";
                string sql3 = "INSERT INTO inventoryTracker_Category (CategoryType, Description, HexCode) VALUES (@CategoryType, @Description, @HexCode);";



                using var cmd = connection.CreateCommand();
                cmd.CommandText = sql1;
                cmd.ExecuteNonQuery();

                cmd.CommandText = sql2;
                cmd.ExecuteNonQuery();

                //


                string check = "SELECT COUNT(*) FROM InventoryTracker_Category WHERE CategoryType = 'All'";
                using var cmdCount = new MySqlCommand(check, connection);
                if ((long)cmdCount.ExecuteScalar() == 0)
                {
                    using var insertCmd = new MySqlCommand(sql3, connection);
                    insertCmd.Parameters.AddWithValue("@CategoryType", "All");
                    insertCmd.Parameters.AddWithValue("@Description", "Default - All Items");
                    insertCmd.Parameters.AddWithValue("@HexCode", "#F3F3F3");
                    insertCmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }

        }

        public void updateQuantity(int sku, int newValue)
        {
            try
            {
                using var connection = getConnection();
                connection.Open();

                string sql = "UPDATE inventorytracker_items SET Quantity = @Quantity WHERE SKUID = @SKUId";
                using var cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Quantity", newValue);
                cmd.Parameters.AddWithValue("SKUId", sku);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        public List<Item> getAllItems()
        {
            try
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
            catch(Exception ex) 
            {
                return new List<Item>();
            }
            
        }

        public List<Category> getAllCategoires()
        {
            try
            {
                using var connection = getConnection();
                connection.Open();

                string sql = "SELECT * FROM inventorytracker_category";

                var categories = new List<Category>();

                using var cmd = new MySqlCommand(sql, connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var newCategory = new Category
                    {
                        CategoryType = reader.GetString("CategoryType"),
                        Description = reader.GetString("Description"),
                        HexCode = reader.GetString("HexCode"),
                    };

                    categories.Add(newCategory);
                }
                return categories;
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
            
        }
        public void addCategory(Category cat)
        {
            try
            {
                using var connection = getConnection();
                connection.Open();

                string sql = "INSERT INTO inventoryTracker_Category (CategoryType, Description, HexCode) VALUES (@CategoryType, @Description, @HexCode);";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@CategoryType", cat.CategoryType);
                cmd.Parameters.AddWithValue("@Description", cat.Description);
                cmd.Parameters.AddWithValue("@HexCode", cat.HexCode);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }

        public int addItem(Item item)
        {
            try
            {
                using var connection = getConnection();
                connection.Open();

                string sql = "INSERT INTO inventoryTracker_items (ItemName, Description, Quantity, Category, LastUpdated) VALUES (@ItemName, @Description, @Quantity, @Category, @LastUpdated); SELECT LAST_INSERT_ID();";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                cmd.Parameters.AddWithValue("@Description", item.itemDescription);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@Category", item.Category);
                cmd.Parameters.AddWithValue("@LastUpdated", item.LastUpdated);

                int skuId = Convert.ToInt32(cmd.ExecuteScalar());
                return skuId;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

    }
}
