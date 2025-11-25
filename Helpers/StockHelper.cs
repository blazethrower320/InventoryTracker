using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Helpers
{
    public class StockHelper
    {
        public static int countStock(ObservableCollection<Item> items, int threshold)
        {
            int low = 0;
            foreach (Item item in items)
            {
                if(item.Quantity <= threshold) low++;
            }
            return low;

        }
    }
}
