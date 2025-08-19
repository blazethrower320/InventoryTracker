using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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

        vm.CategoryList.Add(new Models.Category
        {
            CategoryType = categoryName.Text,
            HexCode = categoryHexCode.Text,
            Description = categoryDescription.Text,

        });
        vm.CreateCategory();
    }
}