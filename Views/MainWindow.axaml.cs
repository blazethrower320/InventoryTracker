using Avalonia.Controls;
using InventoryTracker.ViewModels;
using System;

namespace InventoryTracker.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}