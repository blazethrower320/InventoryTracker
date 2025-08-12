using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InventoryTracker.ViewModels;

namespace InventoryTracker;

public partial class NewProductPage : UserControl
{
    public NewProductPage()
    {
        InitializeComponent();
        DataContext = new NewProductViewModel();
    }
}