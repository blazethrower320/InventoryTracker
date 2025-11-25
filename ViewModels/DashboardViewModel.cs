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
        [ObservableProperty]
        private ObservableCollection<Item> displayedItems;
        public Search SearchType { get; }
        public Thresholds thresholds { get; }
        public DashboardViewModel(MainWindowViewModel mainVM)
        {
            AllItems = mainVM.AllItems;
            displayedItems = mainVM.DisplayedItems;
            SearchType = mainVM.Search;
            thresholds = mainVM.thresholds;

        }
    }
}
