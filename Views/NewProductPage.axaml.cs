using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InventoryTracker.Database;
using InventoryTracker.Models;
using InventoryTracker.ViewModels;
using System;
using System.Runtime.Intrinsics.X86;

namespace InventoryTracker;

public partial class NewProductPage : UserControl
{
    public NewProductPage()
    {
        InitializeComponent();
    }
    private void CreateProduct_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var vm = this.DataContext as NewProductViewModel;

        string ItemName = itemName.Text;
        int ItemQuantity = Int32.Parse(itemQuantity.Text);
        var selectedCategory = itemCategory.SelectedItem as Category;
        string ItemCategory = selectedCategory?.CategoryType ?? "";
        string ItemDescription = itemDescription.Text;

        var newItem = new Models.Item
        {
            ItemName = ItemName,
            Category = ItemCategory,
            Quantity = ItemQuantity,
            itemDescription = ItemDescription,
            LastUpdated = DateTime.Now,
        };

       
        var id = vm.database.addItem(newItem);

        newItem.SkuID = id;

        vm.AllItems.Add(newItem);

        vm.CreateProduct();
    }
}