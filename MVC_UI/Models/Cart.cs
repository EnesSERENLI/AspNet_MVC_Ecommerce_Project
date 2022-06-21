using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_UI.Models
{
    public class Cart
    {
        Dictionary<Guid,CartItem> _myCart = new Dictionary<Guid,CartItem>();

        public List<CartItem> myCart 
        {
            get
            {
                return _myCart.Values.ToList();
            } 
        }

        public void AddItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.Id))
            {
                _myCart[cartItem.Id].Quantity += cartItem.Quantity;
                return;
            }
            _myCart.Add(cartItem.Id, cartItem);
        }
    }
}