using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using OnlineStore.Models;
using OnlineStore.Repos;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
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
        Task<bool> Eliminar(int id);
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
                return 0;

            return cart != null ? cart.Items.Count : 0;
        }

        public async Task Add(Product item, int qty)
        {
            if (qty < 1)
                return;
            var cart_item = new CartItem() { Product_id = item.Id, Qty = qty, Price = item.Price };
            var cart = await _localStorage.GetItemAsync<Cart>("cart");
            if (cart == null)
            {
                cart = new Cart();
                cart.Items.Add(cart_item);
                goto end;
            }
            var update = cart.Items.FirstOrDefault(x => x.Product_id.Equals(item.Id));
            if (update == null)
            {
                cart.Items.Add(cart_item);
            }
            else
            {
                cart.Items.Find(x => x.Product_id.Equals(item.Id)).Qty += qty;
            }
            end:
            await _localStorage.SetItemAsync("cart", cart);
            _toastService.ShowInfo(item.Name, "Añadido al carrito");
            await _observer.NotifyStateChangedAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            return true;
        }

    }
}
