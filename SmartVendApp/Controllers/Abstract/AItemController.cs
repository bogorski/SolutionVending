namespace SmartVendApp.Controllers.Abstract
{
    public abstract class AItemController<TForView, TKey> where TForView : class, new()
    {
        public bool IsLoading { get; protected set; }
        public bool ShowForm { get; protected set; }
        public string? ErrorMessage { get; protected set; }  // Dodany znak ? dla nullable
        public TForView CurrentItem { get; protected set; } = new TForView();
        public List<TForView> Items { get; protected set; } = new List<TForView>();

        public virtual void ShowEditor(TForView? item = null)  // Dodany znak ? dla nullable
        {
            CurrentItem = item ?? new TForView();
            ShowForm = true;
        }

        public virtual void CancelEdit()
        {
            ShowForm = false;
        }

        protected abstract Task LoadDataAsync();
        protected abstract Task<bool> SaveItemAsync(TForView item);
        protected abstract Task<bool> DeleteItemAsync(TKey id);
    }
}