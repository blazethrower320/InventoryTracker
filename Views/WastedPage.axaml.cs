using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InventoryTracker.Helpers;
using InventoryTracker.Models;
using InventoryTracker.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace InventoryTracker;

public partial class WastedPage : UserControl
{
    public WastedPage()
    {
        InitializeComponent();
    }
    private void RemoveQuantity_Button(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Item item)
        {
            var vm = this.DataContext as WastedViewModel;
            vm.RemoveQuantity(item);
        }
    }
    private void AddQuantity_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Item item)
        {
            var vm = this.DataContext as WastedViewModel;
            vm.AddQuantity(item);
        }
    }
    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox tb && DataContext is WastedViewModel vm)
        {
            vm.SearchType.SearchText = tb.Text;
            FormatHelper.FormatSearch(vm.DisplayedItems, vm.AllItems, tb.Text);
            //vm.FormatSearch();
        }
    }

    private void QuantityTextBox_Changed(object? sender, TextChangedEventArgs e)
    {
        if(sender is TextBox textbx && textbx.Tag is Item item && DataContext is WastedViewModel vm)
        {
            if (int.TryParse(textbx.Text, out int newQty))
            {
                vm.database.updateQuantity(item.skuID, newQty);
                item.Quantity = newQty;
            }
        }
    }
}