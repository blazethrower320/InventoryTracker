using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using InventoryTracker.Database;
using InventoryTracker.Models;
using InventoryTracker.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
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

        if (string.IsNullOrWhiteSpace(itemName.Text))
        {
            itemName.BorderBrush = Brushes.Red;
            nameError.IsVisible = true;
            nameError.Text = "Please enter a Item Name";
            return;
        }

        var itemExists = vm.AllItems.FirstOrDefault(c => c.ItemName.Equals(itemName.Text, StringComparison.OrdinalIgnoreCase));
        if (itemExists != null)
        {
            itemName.BorderBrush = Brushes.Red;
            nameError.IsVisible = true;
            nameError.Text = "Item Name already Exists!";
            return;
        }

        itemName.BorderBrush = Brushes.Gray;
        nameError.IsVisible = false;
        if (!int.TryParse(itemQuantity.Text, out var quantity))
        {
            itemQuantity.BorderBrush = Brushes.Red;
            quantityError.IsVisible = true;
            return;
        }
        itemQuantity.BorderBrush = Brushes.Gray;
        quantityError.IsVisible = false;
        var selectedCategory = itemCategory.SelectedItem as Category;
        string ItemCategory = selectedCategory?.CategoryType ?? "";
        Debug.WriteLine("Category: " + ItemCategory);
        if(string.IsNullOrWhiteSpace(ItemCategory))
        {
            itemCategory.BorderBrush = Brushes.Red;
            categoryError.IsVisible = true;
            return;
        }
        itemCategory.BorderBrush = Brushes.Gray;
        categoryError.IsVisible = false;

        if (string.IsNullOrWhiteSpace(itemDescription.Text))
        {
            itemDescription.BorderBrush = Brushes.Red;
            descriptionError.IsVisible = true;
            return;
        }
        itemDescription.BorderBrush = Brushes.Gray;
        descriptionError.IsVisible = false;

        var newItem = new Models.Item
        {
            ItemName = itemName.Text,
            Category = ItemCategory,
            Quantity = quantity,
            itemDescription = itemDescription.Text,
            LastUpdated = DateTime.Now,
        };

       
        var id = vm.database.addItem(newItem);

        newItem.SkuID = id;

        vm.AllItems.Add(newItem);

        vm.CreateProduct();
    }
}