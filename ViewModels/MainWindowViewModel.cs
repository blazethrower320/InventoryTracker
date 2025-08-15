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

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private object currentPage;

    public DashboardViewModel DashboardPage { get; }
    public WastedViewModel WastedPage { get; }
    public NewProductViewModel NewProductPage { get; }
    public NewCategoryViewModel NewCategoryPage { get; }

    public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToWastedCommand { get; }
    public ICommand NavigateToNewProductCommand { get; }
    public ICommand NavigateToNewCategoryCommand { get; }

    public MainWindowViewModel()
    {
        WastedPage = new WastedViewModel(NavigateToNewProduct, NavigateToNewCategory);
        DashboardPage = new DashboardViewModel();
        NewProductPage = new NewProductViewModel();
        NewCategoryPage = new NewCategoryViewModel();

        NavigateToDashboardCommand = new RelayCommand(NavigateToDashboard);
        NavigateToWastedCommand = new RelayCommand(NavigateToWasted);
        NavigateToNewProductCommand = new RelayCommand(NavigateToNewProduct);
        NavigateToNewCategoryCommand = new RelayCommand(NavigateToNewCategory);

        CurrentPage = DashboardPage;
    }

    private void NavigateToNewProduct()
    {
        CurrentPage = NewProductPage;
    }
    private void NavigateToNewCategory()
    {
        CurrentPage = NewCategoryPage;
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
