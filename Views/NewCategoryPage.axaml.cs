using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using InventoryTracker.Models;
using InventoryTracker.ViewModels;
using System;

namespace InventoryTracker;

public partial class NewCategoryPage : UserControl
{
    public NewCategoryPage()
    {
        InitializeComponent();
    }
    private void CreateCategory_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var vm = this.DataContext as NewCategoryViewModel;

        if(string.IsNullOrWhiteSpace(categoryName.Text))
        {
            categoryName.BorderBrush = Brushes.Red;
            categoryNameError.IsVisible = true;
            return;
        }
        categoryName.BorderBrush = Brushes.Gray;
        categoryNameError.IsVisible = false;
        if (string.IsNullOrWhiteSpace(categoryHexCode.Text))
        {
            categoryHexCode.BorderBrush = Brushes.Red;
            categoryColorError.IsVisible = true;
            return;
        }
        categoryHexCode.BorderBrush = Brushes.Gray;
        categoryColorError.IsVisible = false;
        if (string.IsNullOrWhiteSpace(categoryDescription.Text))
        {
            categoryDescription.BorderBrush = Brushes.Red;
            categoryDescriptionError.IsVisible = true;
            return;
        }
        categoryDescription.BorderBrush = Brushes.Gray;
        categoryDescriptionError.IsVisible = false;
        var newCat = new Category
        {
            CategoryType = categoryName.Text,
            HexCode = categoryHexCode.Text,
            Description = categoryDescription.Text,
        };

        vm.CategoryList.Add(newCat);
        vm.database.addCategory(newCat);
        vm.CreateCategory();
    }
}