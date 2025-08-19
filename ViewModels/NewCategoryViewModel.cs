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
    public class NewCategoryViewModel : ObservableObject
    {
        public ObservableCollection<Category> CategoryList { get; }
        private readonly Action _navigateToWasted;
        public ICommand CreateCategoryCommand { get; }


        public NewCategoryViewModel(ObservableCollection<Category> categoryList, Action navigateToWasted)
        {
            CategoryList = categoryList;
            _navigateToWasted = navigateToWasted;

            CreateCategoryCommand = new RelayCommand(CreateCategory);
        }
        public void CreateCategory()
        {
            _navigateToWasted?.Invoke();
        }
    }
}
