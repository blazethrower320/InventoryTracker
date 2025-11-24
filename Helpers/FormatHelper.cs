using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Helpers
{
    public class FormatHelper
    {
        public static void FormatSearch(ObservableCollection<Item> displayedItems, ObservableCollection<Item> allItems, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                displayedItems.Clear();
                foreach (var item in allItems)
                    displayedItems.Add(item);
                return;
            }

            var filteredItems = allItems
                .Where(i => (!string.IsNullOrEmpty(i.ItemName) && i.ItemName.Contains(searchText, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            displayedItems.Clear();
            foreach (var item in filteredItems)
                displayedItems.Add(item);
        }
    }
}
