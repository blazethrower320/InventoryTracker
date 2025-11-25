using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using InventoryTracker.ViewModels;
using InventoryTracker.Views;
using InventoryTracker.Database;
using System.IO;
using InventoryTracker.Models;
using System;
using System.Diagnostics;
using InventoryTracker.Helpers;

namespace InventoryTracker;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins

            if(!File.Exists("DatabaseSettings.json"))
            {
                JsonHelper.WriteJson("DatabaseSettings.json", new DatabaseSettings());
            }
            if(!File.Exists("InventoryTrackerSettings.json"))
            {
                JsonHelper.WriteJson("InventoryTrackerSettings.json", new Thresholds());
            }

            var databaseSettings = JsonHelper.ReadConfiguration<DatabaseSettings>("DatabaseSettings.json");
            DatabaseManager db = null;
            try
            {
                db = new DatabaseManager(databaseSettings);
                db.createTables();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Database no Exists");
            }

            var thresholds = JsonHelper.ReadConfiguration<Thresholds>("InventoryTrackerSettings.json");


            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(db, databaseSettings, thresholds),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}