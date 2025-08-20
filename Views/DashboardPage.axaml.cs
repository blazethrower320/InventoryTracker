using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InventoryTracker.ViewModels;

namespace InventoryTracker;

public partial class DashboardPage : UserControl
{
    public DashboardPage()
    {
        InitializeComponent();
    }
    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is TextBox tb && DataContext is DashboardViewModel vm)
        {
            vm.SearchType.SearchText = tb.Text;
            vm.FormatSearch();
        }
    }
}