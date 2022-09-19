﻿using Blazored.LocalStorage;
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
        Task Add(Product item);
        Task<bool> Eliminar(int id);
    }

    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;


        public CartService(ILocalStorageService localStorage, IToastService toastService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
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

        public async Task Add(Product item)
        {
            var cart_item = new CartItem() { Product_id = item.Id, Qty = item.Qty, Price = item.Price };
            var cart = await _localStorage.GetItemAsync<Cart>("cart");
            if (cart == null)
                cart = new Cart();
            cart.Items.Add(cart_item);
            await _localStorage.SetItemAsync("cart", cart);
            _toastService.ShowInfo(item.Name, "Añadido al carrito");
        }

        public async Task<bool> Eliminar(int id)
        {
            return true;
        }

    }
}
