using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InventoryTracker.Models;
using InventoryTracker.ViewModels;
using System;

namespace InventoryTracker;

public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void SaveDatabaseSettings_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if(sender is SettingsViewModel vm && sender is Button button)
        {
            string database = databaseText.Text;
            string server = serverText.Text;
            string username = usernameText.Text;
            string password = passwordText.Text;


            // TODO: Need to save to json file in the future
            vm.database = database;
            vm.server = server;
            vm.username = username;
            vm.password = password;
        }

    }
}