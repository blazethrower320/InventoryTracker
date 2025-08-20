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
        public DashboardViewModel(ObservableCollection<Item> items, ObservableCollection<Item> displayed, Search search)
        {
            AllItems = items;
            displayedItems = displayed;
            SearchType = search;
        }
        public void FormatSearch()
        {
            // if no search text, show all items
            if (string.IsNullOrWhiteSpace(SearchType.SearchText))
            {
                DisplayedItems.Clear();
                foreach (var item in AllItems)
                    DisplayedItems.Add(item);
                return;
            }

            // otherwise, filter
            var items = AllItems
                .Where(c => c.ItemName.Contains(SearchType.SearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            DisplayedItems.Clear();
            foreach (var item in items)
                DisplayedItems.Add(item);
        }
    }
}
