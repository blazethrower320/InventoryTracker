using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Models
{
    public class DatabaseSettings
    {
        public string Server {  get; set; }
        public string Database {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
