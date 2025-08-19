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

    public ObservableCollection<Item> AllItems { get; }
    public ObservableCollection<Category> CategoryList { get; }

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
        AllItems = new ObservableCollection<Item>
        {
            new Item { SKUID = "SKU001", ItemName = "Apple iPhone 14", Quantity = 25, Category = "Electronics", LastUpdated = DateTime.Now },
            new Item { SKUID = "SKU002", ItemName = "Samsung Galaxy S23", Quantity = 15, Category = "Electronics", LastUpdated = DateTime.Now.AddDays(-1) },
            new Item { SKUID = "SKU003", ItemName = "Dell Laptop", Quantity = 8, Category = "Computers", LastUpdated = DateTime.Now.AddDays(-2) },
            new Item { SKUID = "SKU004", ItemName = "Office Chair", Quantity = 3, Category = "Furniture", LastUpdated = DateTime.Now.AddDays(-3) },
            new Item { SKUID = "SKU005", ItemName = "Wireless Mouse", Quantity = 0, Category = "Accessories", LastUpdated = DateTime.Now.AddDays(-4) }
        };
        CategoryList = new ObservableCollection<Category>
        {
            new Category {CategoryType = "All" },
            new Category { CategoryType = "Electronics" },
            new Category { CategoryType = "Clothing" },
            new Category { CategoryType = "Accessories" }
        };


        DashboardPage = new DashboardViewModel(AllItems);
        WastedPage = new WastedViewModel(AllItems, CategoryList, NavigateToNewProduct, NavigateToNewCategory);

        NewProductPage = new NewProductViewModel(AllItems, CategoryList, NavigateToWasted);
        NewCategoryPage = new NewCategoryViewModel(CategoryList, NavigateToWasted);

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
