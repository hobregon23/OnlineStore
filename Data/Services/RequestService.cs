using Blazored.Toast.Services;
using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IRequestService
    {
        Task Add(Check_Out item, Cart cart, bool need_shipping);
        Task<List<Request>> GetAll();
        Task<bool> VerifyItemQty(List<CartItem> items);
    }

    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;
        private readonly IToastService _toastService;

        public RequestService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork,
            IToastService toastService)
        {
            _jwtAuthService = jwtAuthService;
            _toastService = toastService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> VerifyItemQty(List<CartItem> items)
        {
            var withProblem = new List<string>();
            foreach (var item in items)
            {
                var prod = await _unitOfWork.Products.GetById(item.Product_id);
                if (prod.Qty < item.Qty)
                {
                    withProblem.Add(item.Product_name.Length > 30 ? item.Product_name.Substring(0, 30) + "..." : item.Product_name + " solo quedan " + item.Qty);
                }
            }
            if (withProblem.Count > 0)
            {
                foreach (var item in withProblem)
                {
                    _toastService.ShowError(item, "Cantidad insuficiente");
                }
                return false;
            }
            return true;
        }

        public async Task Add(Check_Out item, Cart cart, bool need_shipping)
        {
            var userAddress = await _unitOfWork.Addresses.GetById(item.Address.Id);
            var request = new Request
            {
                Full_name_receptor = item.Full_name,
                User_id = await _jwtAuthService.GetUserId(),
                Address_id = item.Address.Id,
                Status = "Pendiente",
                Price = cart.Total_amount - item.Shipping_price,
                Shipping_price = item.Shipping_price,
                Created_at = DateTime.Now,
                IsActive = true,
                Need_shipping = need_shipping
            };
            if (userAddress.Address_line != item.Address.Address_line ||
                userAddress.City != item.Address.City ||
                userAddress.State != item.Address.State ||
                userAddress.Postal_code != item.Address.Postal_code ||
                userAddress.Province_id != item.Address.Province_id)
            {
                request.Address = new Address()
                {
                    Address_line = item.Address.Address_line,
                    City = item.Address.City,
                    State = item.Address.State,
                    Postal_code = item.Address.Postal_code,
                    Province_id = item.Address.Province_id,
                    Province = null
                };
                request.Address_id = request.Address.Id;
            }
            var req = await _unitOfWork.Requests.Add(request);
            await _unitOfWork.SaveChangesAsync();

            var req_items = FillListItems(cart.Items, req.Entity.Id);
            await SaveRequestItems(req_items);

            _toastService.ShowInfo("Gracias por comprar con nosotros.", "Pedido creado");
        }

        private async Task SaveRequestItems(List<Request_Item> items)
        {
            foreach (var item in items)
            {
                await _unitOfWork.Request_Items.Add(item);
                await _unitOfWork.SaveChangesAsync();
                await RebajarProducto(item.Product_id, item.Qty);
            }
        }

        private async Task RebajarProducto(int id, int qty)
        {
            await _unitOfWork.Products.Rebajar(id, qty);
        }

        private List<Request_Item> FillListItems(List<CartItem> items, int req_id)
        {
            var list = new List<Request_Item>();
            foreach (var item in items)
            {
                var temp = new Request_Item()
                {
                    Created_at = DateTime.Now,
                    Request_id = req_id,
                    Product_id = item.Product_id,
                    Total_import = item.Price * item.Qty,
                    Qty = item.Qty,
                    IsActive = true
                };
                list.Add(temp);
            }
            return list;
        }

        public async Task<List<Request>> GetAll()
        {
            return await _unitOfWork.Requests.GetAllIncludingItems();
        }

    }
}
