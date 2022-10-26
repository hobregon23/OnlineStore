using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IAppointmentService
    {
        Task<string> Add(Appointment item);
        Task<PaginationResponse<Appointment>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Appointment> GetById(int id);
        Task<List<Appointment>> GetToday();
        Task<List<Appointment>> GetAll();
        Task<string> Eliminar(int id);
        Task<string> Update(Appointment item);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(Appointment item)
        {
            try
            {
                await _unitOfWork.Appointments.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<Appointment>> GetAll()
        {
            return (await _unitOfWork.Appointments.GetAll()).ToList();
        }

        public async Task<List<Appointment>> GetToday()
        {
            return (await _unitOfWork.Appointments.GetAll()).Where(x => x.Date.Year.Equals(DateTime.Now.Year) && x.Date.Month.Equals(DateTime.Now.Month) && x.Date.Day.Equals(DateTime.Now.Day)).ToList();
        }

        public async Task<PaginationResponse<Appointment>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Appointments.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _unitOfWork.Appointments.GetById(id);
        }

        public async Task<string> Eliminar(int id)
        {
            try
            {
                var item = await GetById(id);
                if (item == null)
                    return "Error, no existe.";
                _unitOfWork.Appointments.Remove(item);
                await _unitOfWork.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<string> Update(Appointment item)
        {
            item.Updated_at = DateTime.Now;
            _unitOfWork.Appointments.Update(item);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
