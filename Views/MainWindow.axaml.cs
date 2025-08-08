using Avalonia.Controls;
using InventoryTracker.ViewModels;
using System;

namespace InventoryTracker.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel ViewModel => (MainWindowViewModel)this.DataContext;
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainWindowViewModel();

        /*
         * ExtendClientAreaToDecorationsHint = true;
        ExtendClientAreaChromeHints = Avalonia.Platform.ExtendClientAreaChromeHints.NoChrome;
        ExtendClientAreaTitleBarHeightHint = -1;
         */
    }

}