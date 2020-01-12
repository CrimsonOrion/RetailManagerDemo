using Caliburn.Micro;

using System.ComponentModel;

namespace RMDesktop.UI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;
        private BindingList<string> _cart;
        private int _itemQuantity;

        public BindingList<string> Products { get => _products; set { _products = value; NotifyOfPropertyChange(() => Products); } }
        public BindingList<string> Cart { get => _cart; set { _cart = value; NotifyOfPropertyChange(() => Cart); } }
        public int ItemQuantity { get => _itemQuantity; set { _itemQuantity = value; NotifyOfPropertyChange(() => ItemQuantity); } }

        public string SubTotal => "$0.00";
        public string Tax => "$0.00";
        public string Total => "$0.00";

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