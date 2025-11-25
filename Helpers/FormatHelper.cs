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
        public static void FormatSearch(ObservableCollection<Item> displayedItems, ObservableCollection<Item> allItems, string searchText, string category)
        {
            IEnumerable<Item> filteredItems = allItems;

            if (!string.IsNullOrWhiteSpace(category) && !category.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                filteredItems = filteredItems.Where(i => i.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredItems = filteredItems.Where(i => !string.IsNullOrEmpty(i.ItemName) && i.ItemName.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }

            displayedItems.Clear();
            foreach (var item in filteredItems)
                displayedItems.Add(item);
        }
    }
}
