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

        public async Task Add(Check_Out item, Cart cart, bool need_shipping)
        {
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
                //rebajar la qty de la tabla productos
            }
        }

        private async Task RebajarProducto(int id)
        {
            
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
