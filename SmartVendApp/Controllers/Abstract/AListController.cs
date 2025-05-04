using SmartVendApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Controllers.Abstract
{
    public abstract class AListController<T, TId> : INotifyPropertyChanged
    {
        protected readonly IDataStore<T, TId> _dataStore;

        private bool _isLoading;
        private string _errorMessage;
        private ObservableCollection<T> _items = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<T> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        protected AListController(IDataStore<T, TId> dataStore)
        {
            _dataStore = dataStore;
        }

        public abstract Task LoadDataAsync();
        public abstract Task<bool> SaveItemAsync(T item);
        public abstract Task<bool> DeleteItemAsync(TId id);

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
