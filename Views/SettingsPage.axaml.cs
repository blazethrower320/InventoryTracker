using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using InventoryTracker.Database;
using InventoryTracker.Helpers;
using InventoryTracker.Models;
using InventoryTracker.ViewModels;
using InventoryTracker.Views;
using System;
using System.Diagnostics;

namespace InventoryTracker;

public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void SaveDatabaseSettings_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is SettingsViewModel vm)
        {
            vm.DbSettings.Database = databaseText.Text;
            vm.DbSettings.Server = serverText.Text;
            vm.DbSettings.Username = usernameText.Text;
            vm.DbSettings.Password = passwordText.Text;

            JsonHelper.WriteJson("DatabaseSettings.json", vm.DbSettings);
            var thresholds = JsonHelper.ReadConfiguration<Thresholds>("InventoryTrackerSettings.json");


            try
            {
                var db = new DatabaseManager(vm.DbSettings);
                db.createTables();

                if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    desktop.MainWindow.DataContext = new MainWindowViewModel(db, vm.DbSettings, thresholds);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    private void SaveThresholdSettings_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (DataContext is SettingsViewModel vm)
        {
            if (!int.TryParse(lowStock.Text, out int lowThreshold))
            {
                lowStock.BorderBrush = Brushes.Red;
                lowStockError.IsVisible = true;
                lowStockError.Text = "Please enter a number!";
                return;
            }
            lowStock.BorderBrush = Brushes.Gray;
            lowStockError.IsVisible = false;

            vm.thresholds.LowStockThreshold = lowThreshold;
            JsonHelper.WriteJson("InventoryTrackerSettings.json", vm.thresholds);

        }
    }
}