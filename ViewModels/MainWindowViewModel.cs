using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryTracker.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private object currentPage;
    public DashboardViewModel DashboardPage { get; } = new DashboardViewModel();
    public WastedViewModel WastedPage { get; } = new WastedViewModel();
    public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToWastedCommand { get; }



    public MainWindowViewModel()
    {
        NavigateToDashboardCommand = new RelayCommand(NavigateToDashboard);
        NavigateToWastedCommand = new RelayCommand(NavigateToWasted);

        CurrentPage = DashboardPage;
    }
    private void NavigateToDashboard()
    {
        CurrentPage = DashboardPage;
    }
    
    private void NavigateToWasted()
    {
        CurrentPage = WastedPage;
    }
}
