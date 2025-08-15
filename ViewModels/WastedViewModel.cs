using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public class WastedViewModel : ViewModelBase
    {
        private readonly Action _navigateToNewProduct;
        private readonly Action _navigateToNewCategory;

        public ICommand NavigateToNewProductCommand { get; }
        public ICommand NavigateToNewCategoryCommand { get; }

        public WastedViewModel(Action navigateToNewProduct = null, Action navigateToNewCategory = null)
        {
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
    }

}
