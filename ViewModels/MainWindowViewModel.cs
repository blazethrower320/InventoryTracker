using CommunityToolkit.Mvvm.ComponentModel;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Threading.Tasks;

namespace InventoryTracker.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Items> allItems = new ObservableCollection<Items>();
    public MainWindowViewModel()
    {
        Task.Run(async () =>
        {
            await Task.Delay(2000);
            allItems.Add(new Items { ItemName = "Water", Quantity = 5, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 1});
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
            allItems.Add(new Items { ItemName = "Dr. Pepper", Quantity = 1, Category = "Drink", LastUpdated = DateTime.Now, SKUID = 2 });
        });
    }
}
