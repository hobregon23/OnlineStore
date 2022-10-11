using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IServiceService
    {
        Task<string> Add(Service item);
        Task<PaginationResponse<Service>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Service> GetById(int id);
        Task<List<Service>> GetAll();
        Task<string> Eliminar(int id);
        Task<string> Update(Service item, List<Used_Product> nuevos, List<Used_Product> quitados);
    }

    public class ServiceService : IServiceService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(Service item)
        {
            try
            {
                await _unitOfWork.Services.Add(item);
                foreach (var it in item.Used_products)
                {
                    await _unitOfWork.Products.Rebajar(it.Product_id, 1);
                }
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch(Exception e)
            {
                return "Error"+e.Message;
            }
        }

        public async Task<List<Service>> GetAll()
        {
            return (await _unitOfWork.Services.GetAll()).ToList();
        }

        public async Task<PaginationResponse<Service>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Services.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<Service> GetById(int id)
        {
            return await _unitOfWork.Services.GetById(id);
        }

        public async Task<string> Eliminar(int id)
        {
            try
            {
                var item = await GetById(id);
                if (item == null)
                    return "Error, no existe.";
                foreach (var it in item.Used_products)
                {
                    _unitOfWork.UsedProducts.Remove(it);
                    var prod = await _unitOfWork.Products.GetById(it.Product_id);
                    prod.Qty += 1;
                    _unitOfWork.Products.Update(prod);
                }
                _unitOfWork.Services.Remove(item);
                await _unitOfWork.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<string> Update(Service item, List<Used_Product> nuevos, List<Used_Product> quitados)
        {
            if (!item.IsActive)
                return "Servicio cerrado";
            var bd = await _unitOfWork.Services.GetById(item.Id);
            bd.Updated_at = DateTime.Now;
            bd.Cantidad = item.Cantidad;
            bd.Costo = item.Costo;
            bd.Descripcion = item.Descripcion;
            bd.GananciaNeta = item.GananciaNeta;
            bd.Ingreso = item.Ingreso;
            bd.IsActive = item.IsActive;
            bd.Precio = item.Precio;
            foreach (var it in nuevos)
            {
                bd.Used_products.Add(it);
                await _unitOfWork.Products.Rebajar(it.Product_id, 1);
            }
            foreach (var it in quitados)
            {
                _unitOfWork.UsedProducts.Remove(it);
                var prod = await _unitOfWork.Products.GetById(it.Product_id);
                prod.Qty += 1;
                _unitOfWork.Products.Update(prod);
            }
            _unitOfWork.Services.Update(bd);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
