using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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
        if(sender is Button button && button.CommandParameter is Item item)
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
            vm.FormatSearch();
        }
    }
}