using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryTracker.Models;
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
        public DatabaseSettings dbSettings;
        [ObservableProperty]
        public Thresholds thresholds;
        
        public ICommand CreateSettingsCommand { get; }

        public SettingsViewModel(Action navigateToSettings, DatabaseSettings settings, Thresholds thresholds)
        {
            _navigateToSettings = navigateToSettings;
            this.thresholds = thresholds;
            this.dbSettings = settings;
            CreateSettingsCommand = new RelayCommand(CreateSettings);
        }
        public void CreateSettings()
        {
            _navigateToSettings?.Invoke();
        }
    }
}
