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
    public Thresholds thresholds;

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

    public MainWindowViewModel(DatabaseManager? database, DatabaseSettings settings, Thresholds thresholds)
    {

        this.database = database;
        this.databaseSettings = settings;
        this.thresholds = thresholds;

        Search = new Search();

        AllItems = new ObservableCollection<Item>();
        CategoryList = new ObservableCollection<Category>();
        if (database != null)
        {
            AllItems = new ObservableCollection<Item>(database.getAllItems());
            CategoryList = new ObservableCollection<Category>(database.getAllCategoires());
        }

        DisplayedItems = new ObservableCollection<Item>(AllItems);


        DashboardPage = new DashboardViewModel(this);
        WastedPage = new WastedViewModel(AllItems, DisplayedItems, CategoryList, Search, database, NavigateToNewProduct, NavigateToNewCategory);

        NewProductPage = new NewProductViewModel(AllItems, CategoryList, NavigateToWasted, database);
        NewCategoryPage = new NewCategoryViewModel(CategoryList, NavigateToWasted, database);

        SettingsPage = new SettingsViewModel(NavigateToSettings, settings, thresholds);

        NavigateToDashboardCommand = new RelayCommand(NavigateToDashboard);
        NavigateToWastedCommand = new RelayCommand(NavigateToWasted);
        NavigateToNewProductCommand = new RelayCommand(NavigateToNewProduct);
        NavigateToNewCategoryCommand = new RelayCommand(NavigateToNewCategory);
        NavigateToSettingsCommand = new RelayCommand(NavigateToSettings);

        CurrentPage = DashboardPage;
    }

    private void NavigateToNewProduct()
    {
        if (NewProductPage == null) return;
        CurrentPage = NewProductPage;
        Search.searchText = string.Empty;
        Search.category = string.Empty;
        FormatHelper.FormatSearch(DisplayedItems, AllItems, Search.searchText, Search.category);
    }
    private void NavigateToNewCategory()
    {
        if (NewCategoryPage == null) return;
        CurrentPage = NewCategoryPage;
        Search.searchText = string.Empty;
        Search.category = string.Empty;
        FormatHelper.FormatSearch(DisplayedItems, AllItems, Search.searchText, Search.category);
    }
    private void NavigateToSettings()
    {
        if (SettingsPage == null) return;
        CurrentPage = SettingsPage;
        Search.searchText = string.Empty;
        Search.category = string.Empty;
    }

    private void NavigateToDashboard()
    {
        if (DashboardPage == null) return;
        CurrentPage = DashboardPage;
        Search.searchText = string.Empty;
        Search.category = string.Empty;
        FormatHelper.FormatSearch(DisplayedItems, AllItems, Search.searchText, Search.category);
    }

    private void NavigateToWasted()
    {
        if(WastedPage == null) return;
        CurrentPage = WastedPage;
        Search.searchText = string.Empty;
        Search.category = string.Empty;
        FormatHelper.FormatSearch(DisplayedItems, AllItems, Search.searchText, Search.category);
    }
}
