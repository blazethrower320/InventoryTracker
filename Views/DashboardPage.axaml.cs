using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using InventoryTracker.Helpers;
using InventoryTracker.ViewModels;
using System;
using System.Runtime.Intrinsics.X86;

namespace InventoryTracker;

public partial class DashboardPage : UserControl
{
    private DashboardViewModel? vm;
    public DashboardPage()
    {
        InitializeComponent();
        this.Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        vm = DataContext as DashboardViewModel;
        if (vm != null)
        {
            lowStockAmount.Text = StockHelper.countStock(vm.AllItems, vm.thresholds.LowStockThreshold).ToString();
            outOfStockAmount.Text = StockHelper.countStock(vm.AllItems, 0).ToString();
            totalItemsAmount.Text = vm.AllItems.Count.ToString();
        }
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox tb && DataContext is DashboardViewModel vm)
        {
            vm.SearchType.SearchText = tb.Text;
            FormatHelper.FormatSearch(vm.DisplayedItems, vm.AllItems, tb.Text, vm.SearchType.category);
        }
    }
}