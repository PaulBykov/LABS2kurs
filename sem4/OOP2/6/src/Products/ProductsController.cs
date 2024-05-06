using System.Collections.ObjectModel;
using System.Windows.Controls;
using static _4.src.Products.Sneaker;

namespace _4.src.Products
{
    public class ProductsController
    {
        private readonly Products _db;
        private Products _filteredDB;
        private DataGrid _dataGrid;
        private FilterSettings _filterSettings = new FilterSettings();

        public ProductsController(Products db, DataGrid dataGrid)
        {
            _db = db;
            _filteredDB = new Products(db.Db);
            _dataGrid = dataGrid;
        }

        public Products getDB {get => _db;}

        public void ResetFilterSettings() 
        {
            _filterSettings = new FilterSettings();
            Filter();
        }
        public void UpdateDataGrid(Products DB)
        {
            _dataGrid.ItemsSource = null;
            _dataGrid.ItemsSource = DB.Db;
        }

        private void FilterBy(Func<Sneaker, bool> filter)
        {
            _filteredDB.Db = new ObservableCollection<Sneaker>(_filteredDB.Db.Where(filter));
        }

        public void Filter(Sneaker.Brands? brand = null, ushort? size = null, string? color = null, ushort? maxPrice = null, string? name=null) 
        {
            _filteredDB.Db = _db.Db;
            //rewrite settings
            if (brand != null)   { _filterSettings.Brand = (Brands)brand; }
            if (size != null)    { _filterSettings.Size = (ushort)size; }
            if (color != null)   { _filterSettings.Color = (string)color; } 
            if (maxPrice != null){ _filterSettings.MaxPrice = (ushort)maxPrice; }
            if (name != null)    { _filterSettings.Name = (string)name; }

            //filtering
            if(_filterSettings.Brand != null) FilterBy(sneaker => sneaker.Brand == _filterSettings.Brand);
            if (_filterSettings.Size != null) FilterBy(sneaker => sneaker.Size == _filterSettings.Size);
            if (_filterSettings.Color != null) FilterBy(sneaker => sneaker.Color == _filterSettings.Color);
            if (_filterSettings.MaxPrice != null) FilterBy(sneaker => sneaker.Price < _filterSettings.MaxPrice);
            if (_filterSettings.Name != null) FilterBy(sneaker => (sneaker.GetBrandName + sneaker.Model).ToLower().Contains(_filterSettings.Name.ToLower()));

            UpdateDataGrid(_filteredDB);
        }
    }
}
