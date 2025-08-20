using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Models
{
    public partial class Search : ObservableObject
    {
        [ObservableProperty]
        public string searchText;
    }
}
