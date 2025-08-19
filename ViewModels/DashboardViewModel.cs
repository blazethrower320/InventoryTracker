using CommunityToolkit.Mvvm.ComponentModel;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryTracker.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        public ObservableCollection<Item> AllItems { get; }
        public DashboardViewModel(ObservableCollection<Item> items)
        {
            AllItems = items;
        }
    }
}
