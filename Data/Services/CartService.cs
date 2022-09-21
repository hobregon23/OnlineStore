﻿using Blazored.LocalStorage;
using Blazored.Toast.Services;
using OnlineStore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface ICartService
    {
        Task<Cart> Get();
        Task<int> GetCount();
        Task<decimal> GetTotalAmount();
        Task Add(Product item, int qty);
        Task Eliminar(int id);
        Task WipeCart();
    }

    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;
        private readonly ComponentStateChangedObserver _observer;

        public CartService(ILocalStorageService localStorage, IToastService toastService, ComponentStateChangedObserver observer)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _observer = observer;
        }

        public async Task<Cart> Get()
        {
            return await _localStorage.GetItemAsync<Cart>("cart");
        }

        public async Task<int> GetCount()
        {
            var cart = await _localStorage.GetItemAsync<Cart>("cart");
            return cart != null ? cart.Items.Count : 0;
        }

        public async Task<decimal> GetTotalAmount()
        {
            var cart = await _localStorage.GetItemAsync<Cart>("cart");
            if (cart == null)
                return 0m;
            decimal res = 0m;
            foreach (var item in cart.Items)
            {
                res += item.Qty * item.Price;
            }
            return res;
        }

        public async Task Add(Product item, int qty)
        {
            if (qty < 1)
                return;
            var cart_item = new CartItem() { Product_id = item.Id, Qty = qty, Price = item.Price, Product_name = item.Name, Image_url = item.Image_url };
            var cart = await _localStorage.GetItemAsync<Cart>("cart");
            if (cart == null)
            {
                cart = new Cart();
                cart.Items.Add(cart_item);
                goto end;
            }
            var update = cart.Items.FirstOrDefault(x => x.Product_id.Equals(item.Id));
            if (update == null)
                cart.Items.Add(cart_item);
            else
                cart.Items.Find(x => x.Product_id.Equals(item.Id)).Qty += qty;
            end:
            await _localStorage.SetItemAsync("cart", cart);
            _toastService.ShowInfo(item.Name, "Añadido al carrito");
            await _observer.NotifyStateChangedAsync();
        }

        public async Task Eliminar(int id)
        {
            var cart = await _localStorage.GetItemAsync<Cart>("cart");
            if (cart == null)
                return;
            var cartItem = cart.Items.Find(x => x.Product_id.Equals(id));
            cart.Items.Remove(cartItem);
            await _localStorage.SetItemAsync("cart", cart);
            _toastService.ShowInfo("Producto eliminado del carrito", "Eliminado");
            await _observer.NotifyStateChangedAsync();
        }

        public async Task WipeCart()
        {
            await _localStorage.RemoveItemAsync("cart");
        }

    }
}
