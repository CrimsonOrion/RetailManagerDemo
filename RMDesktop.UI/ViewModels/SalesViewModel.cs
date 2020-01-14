using Caliburn.Micro;

using RMDesktop.Library.Api;
using RMDesktop.Library.Helpers;
using RMDesktop.Library.Models;

using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RMDesktop.UI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<ProductModel> _products = new BindingList<ProductModel>();
        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();
        private int _itemQuantity = 1;
        private ProductModel _selectedProduct;
        private readonly IProductEndpoint _productEndpoint;
        private readonly IConfigHelper _configHelper;

        public BindingList<ProductModel> Products { get => _products; set { _products = value; NotifyOfPropertyChange(() => Products); } }
        public BindingList<CartItemModel> Cart { get => _cart; set { _cart = value; NotifyOfPropertyChange(() => Cart); } }

        public ProductModel SelectedProduct { get => _selectedProduct; set { _selectedProduct = value; NotifyOfPropertyChange(() => SelectedProduct); NotifyOfPropertyChange(() => CanAddToCart); } }
        public int ItemQuantity { get => _itemQuantity; set { _itemQuantity = value; NotifyOfPropertyChange(() => ItemQuantity); NotifyOfPropertyChange(() => CanAddToCart); } }

        public string SubTotal => CalculateSubTotal().ToString("C");
        public string Tax => CalculateTax().ToString("C");
        public string Total => (CalculateSubTotal() + CalculateTax()).ToString("C");

        public SalesViewModel(IProductEndpoint productEndpoint, IConfigHelper configHelper)
        {
            _productEndpoint = productEndpoint;
            _configHelper = configHelper;
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadProducts();
            base.OnViewLoaded(view);
        }

        public async Task LoadProducts()
        {
            var products = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(products);
        }

        public bool CanAddToCart => ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity;

        public void AddToCart()
        {
            var existingItem = Cart.FirstOrDefault(_ => _.Product == SelectedProduct);

            if (existingItem != null)
            {
                existingItem.QuantityInCart += ItemQuantity;
                // HACK: There's a better way to do this.
                Cart.Remove(existingItem);
                Cart.Add(existingItem);
            }
            else
            {
                var item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(item);
            }

            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
        }

        public bool CanRemoveFromCart
        {
            get
            {
                var output = false;

                return output;
            }
        }

        public void RemoveFromCart()
        {
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
        }

        public bool CanCheckOut
        {
            get
            {
                var output = false;

                return output;
            }
        }

        public void CheckOut()
        {

        }

        private decimal CalculateSubTotal() => Cart.Sum(_ => _.Product.RetailPrice * _.QuantityInCart);

        private decimal CalculateTax() => Cart.Where(_ => _.Product.IsTaxable).Sum(_ => _.Product.RetailPrice * _.QuantityInCart * (_configHelper.GetTaxRate() / 100));
    }
}