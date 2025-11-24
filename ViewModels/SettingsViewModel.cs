using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryTracker.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        private readonly Action _navigateToSettings;
        [ObservableProperty]
        public string username = "root";
        [ObservableProperty]
        public string password = "password";
        [ObservableProperty]
        public string database = "Test";
        [ObservableProperty]
        public string server = "127.0.0.1";
        public ICommand CreateSettingsCommand { get; }

        public SettingsViewModel(Action navigateToSettings)
        {
            _navigateToSettings = navigateToSettings;
            CreateSettingsCommand = new RelayCommand(CreateSettings);
        }
        public void CreateSettings()
        {
            _navigateToSettings?.Invoke();
        }
    }
}
