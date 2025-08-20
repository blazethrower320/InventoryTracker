using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace InventoryTracker.ViewModels
{
    public partial class WastedViewModel : ViewModelBase
    {
        public ObservableCollection<Item> AllItems { get; }
        [ObservableProperty]
        private ObservableCollection<Item> displayedItems;
        public ObservableCollection<Category> CategoryList { get; }
        public Search SearchType { get; }

        private readonly Action _navigateToNewProduct;
        private readonly Action _navigateToNewCategory;

        public ICommand NavigateToNewProductCommand { get; }
        public ICommand NavigateToNewCategoryCommand { get; }

        public WastedViewModel(ObservableCollection<Item> allItems, ObservableCollection<Item> displayeditems, ObservableCollection<Category> categoryList, Search search, Action navigateToNewProduct = null, Action navigateToNewCategory = null)
        {
            AllItems = allItems;
            displayedItems = allItems;
            CategoryList = categoryList;
            SearchType = search;
            _navigateToNewProduct = navigateToNewProduct;
            _navigateToNewCategory = navigateToNewCategory;

            NavigateToNewProductCommand = new RelayCommand(NavigateToNewProduct);
            NavigateToNewCategoryCommand = new RelayCommand(NavigateToNewCategory);
        }


        private void NavigateToNewProduct()
        {
            _navigateToNewProduct?.Invoke();
        }
        private void NavigateToNewCategory()
        {
            _navigateToNewCategory?.Invoke();
        }
        public void AddQuantity(Item item)
        {
            var foundItem = AllItems.FirstOrDefault(c => c.Equals(item));
            if (foundItem == null) return;
            foundItem.Quantity += 1;
        }
        public void RemoveQuantity(Item item)
        {
            var foundItem = AllItems.FirstOrDefault(c => c.Equals(item));
            if (foundItem == null) return;
            if (foundItem.Quantity == 0) return;
            foundItem.Quantity -= 1;
        }
        public void FormatSearch()
        {

            var items = AllItems
            .Where(c => c.ItemName.Contains(SearchType.SearchText, StringComparison.OrdinalIgnoreCase))
            .ToList();

            displayedItems = new ObservableCollection<Item>(items);
        }
    }

}
