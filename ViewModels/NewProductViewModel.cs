using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryTracker.Database;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryTracker.ViewModels
{
    public partial class NewProductViewModel : ObservableObject
    {
        public DatabaseManager database;
        public ObservableCollection<Item> AllItems { get; }
        public ObservableCollection<Category> CategoryList { get; }
        private readonly Action _navigateToWasted;
        public ICommand CreateProductCommand { get; }


        public NewProductViewModel(ObservableCollection<Item> allItems, ObservableCollection<Category> categoryList, Action navigateToWasted, DatabaseManager database)
        {
            this.database = database;
            AllItems = allItems;
            CategoryList = categoryList;
            _navigateToWasted = navigateToWasted;

            CreateProductCommand = new RelayCommand(CreateProduct);
        }
        public void CreateProduct()
        {
            _navigateToWasted?.Invoke();
        }
    }
}
