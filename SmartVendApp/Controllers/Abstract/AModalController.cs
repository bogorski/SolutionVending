using AutoMapper;
using System.Diagnostics;
using System.Text.Json;

namespace SmartVendApp.Controllers.Abstract
{
    public abstract class AModalController<T> where T : new()
    {
        private static readonly IMapper _mapper = new MapperConfiguration(cfg => cfg.CreateMap<T, T>()).CreateMapper();
        public bool ShowModal { get; set; }
        public T CurrentItem { get; set; }
        public bool IsNew { get; set; }
        public string Title { get; protected set; }

        public abstract Task<bool> SaveAsync();

        public void ShowAddModal()
        {
            CurrentItem = Activator.CreateInstance<T>();
            IsNew = true;
            ShowModal = true;
        }

        public void ShowEditModal(T item)
        {
            CurrentItem = _mapper.Map<T>(item);

            Debug.WriteLine(JsonSerializer.Serialize(CurrentItem, new JsonSerializerOptions { WriteIndented = true }));
            IsNew = false;
            ShowModal = true;
        }

        public void CloseModal() => ShowModal = false;
    }
}
/*
using AutoMapper;
using System.Text.Json;

namespace SmartVendApp.Controllers.Abstract
{
    public abstract class AModalController<T>
    {
        private static readonly IMapper _mapper;
        private bool _showModal;
        private T _currentItem;
        private bool _isNew;

        static AModalController()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, T>());
            _mapper = config.CreateMapper();
        }

        public bool ShowModal
        {
            get => _showModal;
            set
            {
                _showModal = value;
            }
        }

        public T CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
            }
        }

        public bool IsNew
        {
            get => _isNew;
            set
            {
                _isNew = value;
            }
        }

        public string Title { get; protected set; }

        public abstract Task<bool> SaveAsync();

        public void ShowAddModal()
        {
            CurrentItem = Activator.CreateInstance<T>();
            IsNew = true;
            ShowModal = true;
        }

        public void ShowEditModal(T item)
        {
            CurrentItem = _mapper.Map<T>(item);

            System.Diagnostics.Debug.Print(
                JsonSerializer.Serialize(CurrentItem, new JsonSerializerOptions { WriteIndented = true })
            );
            IsNew = false;
            ShowModal = true;
        }

        public void CloseModal()
        {
            ShowModal = false;
        }
    }
}*/
