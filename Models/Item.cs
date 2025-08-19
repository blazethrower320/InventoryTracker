using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Models
{
    public partial class Item : ObservableObject
    {
        public string SKUID { get; set; }
        public string ItemName { get; set; }
        [ObservableProperty]
        public int quantity;
        public string Category { get; set; }
        public DateTime LastUpdated {  get; set; }

    }
}
