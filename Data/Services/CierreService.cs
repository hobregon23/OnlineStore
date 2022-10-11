using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface ICierreService
    {
        Task<int> Create();
        Task<PaginationResponse<Cierre>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Cierre> GetById(int id);
    }

    public class CierreService : ICierreService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public CierreService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create()
        {
            try
            {
                var item = new Cierre();
                var list = (await _unitOfWork.Services.GetAll()).Where(x => x.IsActive).ToList();
                item.F_inicio = list[0].Created_at;
                item.F_fin = list[list.Count - 1].Created_at;
                foreach (var it in list)
                {
                    it.IsActive = false;
                    item.Costo += it.Costo;
                    item.Ganancia += it.GananciaNeta;
                    item.Ingreso += it.Ingreso;
                    if (it.Tipo.Equals("Venta"))
                        item.Qty_ventas += 1;
                    else
                        item.Qty_reparaciones += 1;
                    _unitOfWork.Services.Update(it);
                }
                await _unitOfWork.Cierres.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<PaginationResponse<Cierre>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Cierres.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<Cierre> GetById(int id)
        {
            return await _unitOfWork.Cierres.GetById(id);
        }
    }
}
