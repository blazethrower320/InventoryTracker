using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryTracker.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InventoryTracker.ViewModels;

public class ViewModelBase : ObservableObject
{
    public ObservableCollection<Item> AllItems { get; set; }
    public ObservableCollection<Category> CategoryList { get; set; }
    public ViewModelBase()
    {

        AllItems = new ObservableCollection<Item>
            {
                new Item { SKUID = "SKU001", ItemName = "Apple iPhone 14", Quantity = 25, Category = "Electronics", LastUpdated = DateTime.Now },
                new Item { SKUID = "SKU002", ItemName = "Samsung Galaxy S23", Quantity = 15, Category = "Electronics", LastUpdated = DateTime.Now.AddDays(-1) },
                new Item { SKUID = "SKU003", ItemName = "Dell Laptop", Quantity = 8, Category = "Computers", LastUpdated = DateTime.Now.AddDays(-2) },
                new Item { SKUID = "SKU004", ItemName = "Office Chair", Quantity = 3, Category = "Furniture", LastUpdated = DateTime.Now.AddDays(-3) },
                new Item { SKUID = "SKU005", ItemName = "Wireless Mouse", Quantity = 0, Category = "Accessories", LastUpdated = DateTime.Now.AddDays(-4) }
            };
        CategoryList = new ObservableCollection<Category>()
            {
            new Category
                {
                    CategoryType = "All",
                    ItemCount = 45,
                },
                new Category
                {
                    CategoryType = "Electronic",
                    ItemCount = 5,
                }
            };
    }
}
