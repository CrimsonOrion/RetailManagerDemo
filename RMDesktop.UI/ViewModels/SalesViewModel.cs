using Caliburn.Micro;

using RMDesktop.Library.Api;
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

        public BindingList<ProductModel> Products { get => _products; set { _products = value; NotifyOfPropertyChange(() => Products); } }
        public BindingList<CartItemModel> Cart { get => _cart; set { _cart = value; NotifyOfPropertyChange(() => Cart); } }

        public ProductModel SelectedProduct { get => _selectedProduct; set { _selectedProduct = value; NotifyOfPropertyChange(() => SelectedProduct); NotifyOfPropertyChange(() => CanAddToCart); } }
        public int ItemQuantity { get => _itemQuantity; set { _itemQuantity = value; NotifyOfPropertyChange(() => ItemQuantity); NotifyOfPropertyChange(() => CanAddToCart); } }

        public string SubTotal
        {
            get
            {
                var subTotal = 0m;

                foreach (var item in Cart)
                {
                    subTotal += (item.Product.RetailPrice * item.QuantityInCart);
                }
                return subTotal.ToString("C");
            }
        }

        public string Tax => "$0.00";
        public string Total => "$0.00";

        public SalesViewModel(IProductEndpoint productEndpoint) => _productEndpoint = productEndpoint;

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

        public bool CanAddToCart
        {
            get
            {
                var output = false;

                if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    output = true;
                }

                return output;
            }
        }

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
    }
}