using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InventoryTracker.Models;
using InventoryTracker.ViewModels;
using System;

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

        vm.AllItems.Add(new Models.Item
        {
            ItemName = ItemName,
            SKUID = "0",
            Category = ItemCategory,
            Quantity = ItemQuantity,
            LastUpdated = DateTime.Now,
        });
        vm.CreateProduct();
    }
}