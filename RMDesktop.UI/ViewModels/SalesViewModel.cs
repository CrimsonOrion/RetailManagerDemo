using Caliburn.Micro;

using RMDesktop.Library.Api;
using RMDesktop.Library.Models;

using System.ComponentModel;
using System.Threading.Tasks;

namespace RMDesktop.UI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<ProductModel> _products;
        private BindingList<ProductModel> _cart;
        private int _itemQuantity;
        private readonly IProductEndpoint _productEndpoint;

        public BindingList<ProductModel> Products { get => _products; set { _products = value; NotifyOfPropertyChange(() => Products); } }
        public BindingList<ProductModel> Cart { get => _cart; set { _cart = value; NotifyOfPropertyChange(() => Cart); } }
        public int ItemQuantity { get => _itemQuantity; set { _itemQuantity = value; NotifyOfPropertyChange(() => ItemQuantity); } }

        public string SubTotal => "$0.00";
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

                return output;
            }
        }

        public void AddToCart()
        {

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