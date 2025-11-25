using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Models
{
    public partial class DatabaseSettings : ObservableObject
    {
        [ObservableProperty]
        private string server = "127.0.0.1";
        [ObservableProperty]
        private string database = "Testingd";
        [ObservableProperty]
        private string username = "root";
        [ObservableProperty]
        private string password = "password";
    }
}
