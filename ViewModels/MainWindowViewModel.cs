using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryTracker.Database;
using InventoryTracker.Helpers;
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
    public Search Search;
    public DatabaseManager database;
    public DatabaseSettings databaseSettings;

    public ObservableCollection<Item> AllItems { get; }
    public ObservableCollection<Category> CategoryList { get; }
    [ObservableProperty]
    private ObservableCollection<Item> displayedItems;
    public DashboardViewModel DashboardPage { get; }
    public WastedViewModel WastedPage { get; }
    public NewProductViewModel NewProductPage { get; }
    public NewCategoryViewModel NewCategoryPage { get; }
    public SettingsViewModel SettingsPage { get; }

    public ICommand NavigateToDashboardCommand { get; }
    public ICommand NavigateToWastedCommand { get; }
    public ICommand NavigateToNewProductCommand { get; }
    public ICommand NavigateToNewCategoryCommand { get; }
    public ICommand NavigateToSettingsCommand { get; }

    public MainWindowViewModel(DatabaseManager database, DatabaseSettings settings)
    {

        this.database = database;
        this.databaseSettings = settings;

        Search = new Search();
        AllItems = new ObservableCollection<Item>(database.getAllItems());
        /*
        AllItems = new ObservableCollection<Item>
        {
            new Item { SKUID = "SKU001", ItemName = "Apple iPhone 14", Quantity = 25, Category = "Electronics", LastUpdated = DateTime.Now },
            new Item { SKUID = "SKU002", ItemName = "Samsung Galaxy S23", Quantity = 15, Category = "Electronics", LastUpdated = DateTime.Now.AddDays(-1) },
            new Item { SKUID = "SKU003", ItemName = "Dell Laptop", Quantity = 8, Category = "Computers", LastUpdated = DateTime.Now.AddDays(-2) },
            new Item { SKUID = "SKU004", ItemName = "Office Chair", Quantity = 3, Category = "Furniture", LastUpdated = DateTime.Now.AddDays(-3) },
            new Item { SKUID = "SKU005", ItemName = "Wireless Mouse", Quantity = 0, Category = "Accessories", LastUpdated = DateTime.Now.AddDays(-4) }
        };
        */
        CategoryList = new ObservableCollection<Category>
        {
            new Category {CategoryType = "All" },
            new Category { CategoryType = "Electronics" },
            new Category { CategoryType = "Clothing" },
            new Category { CategoryType = "Accessories" }
        };
        DisplayedItems = new ObservableCollection<Item>(AllItems);


        DashboardPage = new DashboardViewModel(AllItems, DisplayedItems, Search);
        WastedPage = new WastedViewModel(AllItems, DisplayedItems, CategoryList, Search, database, NavigateToNewProduct, NavigateToNewCategory);

        NewProductPage = new NewProductViewModel(AllItems, CategoryList, NavigateToWasted, database);
        NewCategoryPage = new NewCategoryViewModel(CategoryList, NavigateToWasted);

        SettingsPage = new SettingsViewModel(NavigateToSettings);

        NavigateToDashboardCommand = new RelayCommand(NavigateToDashboard);
        NavigateToWastedCommand = new RelayCommand(NavigateToWasted);
        NavigateToNewProductCommand = new RelayCommand(NavigateToNewProduct);
        NavigateToNewCategoryCommand = new RelayCommand(NavigateToNewCategory);
        NavigateToSettingsCommand = new RelayCommand(NavigateToSettings);

        CurrentPage = DashboardPage;
    }

    private void NavigateToNewProduct()
    {
        CurrentPage = NewProductPage;
        Search.searchText = string.Empty;
        FormatHelper.FormatSearch(DisplayedItems, AllItems, Search.searchText);
    }
    private void NavigateToNewCategory()
    {
        CurrentPage = NewCategoryPage;
        Search.searchText = string.Empty;
        FormatHelper.FormatSearch(DisplayedItems, AllItems, Search.searchText);
    }
    private void NavigateToSettings()
    {
        CurrentPage = SettingsPage;
        Search.searchText = string.Empty;
    }

    private void NavigateToDashboard()
    {
        CurrentPage = DashboardPage;
        Search.searchText = string.Empty;

        FormatHelper.FormatSearch(DisplayedItems, AllItems, Search.searchText);
    }

    private void NavigateToWasted()
    {
        CurrentPage = WastedPage;
        Search.searchText = string.Empty;
        FormatHelper.FormatSearch(DisplayedItems, AllItems, Search.searchText);
    }
}
