using CommunityToolkit.Mvvm.Input;
using InventoryTracker.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace InventoryTracker.ViewModels
{
    public class WastedViewModel : ViewModelBase
    {
        public ObservableCollection<Item> AllItems { get; }
        public ObservableCollection<Category> CategoryList { get; }

        private readonly Action _navigateToNewProduct;
        private readonly Action _navigateToNewCategory;

        public ICommand NavigateToNewProductCommand { get; }
        public ICommand NavigateToNewCategoryCommand { get; }

        public WastedViewModel(ObservableCollection<Item> allItems, ObservableCollection<Category> categoryList, Action navigateToNewProduct = null, Action navigateToNewCategory = null)
        {
            AllItems = allItems;
            CategoryList = categoryList;
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
    }

}
