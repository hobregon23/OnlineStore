using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IStatisticsService
    {
        Task<Statistic> Get();
    }

    public class StatisticsService : IStatisticsService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public StatisticsService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Statistic> Get()
        {
            var stats = new Statistic
            {
                StoreEarnToday = await GetStoreEarnToday(),
                StoreEarnWeek = await GetStoreEarnWeek(),
                StoreEarnTotal = await GetStoreEarnTotal(),
                WorkShopEarnToday = await GetWSEarnToday(),
                WorkShopEarnWeek = await GetWSEarnWeek(),
                WorkShopEarnTotal = await GetWSEarnTotal(),
                EarningsStoreDaily = await GetRequestsByDate("diario"),
                EarningsStoreLife = await GetRequestsByDate("life"),
                EarningsWSDaily = await GetServicesByDate("diario"),
                EarningsWSLife = await GetServicesByDate("life"),
                OrdersToday = await GetTodayOrders(),
                UsersToday = await GetTodayUsers(),
                BestSellingProducts = await GetBestSelling(),
                IdleProducts = await GetIdle()
            };
            stats.EarningsTotal = GetEarningsTotal(stats.EarningsStoreLife, stats.EarningsWSLife);
            return stats;
        }

        private async Task<List<Product>> GetIdle()
        {
            var lis = await _unitOfWork.Request_Items.GetAll();
            var order_items = lis.GroupBy(i => i).OrderBy(grp => grp.Count()).Select(grp => grp.Key).ToList();
            var prod = await _unitOfWork.Products.GetAll();
            var sold_prod = new List<Product>();
            foreach (var item in order_items)
            {
                sold_prod.Add(await _unitOfWork.Products.GetById(item.Product_id));
            }
            var idle = prod.Except(sold_prod).ToList();
            var last5 = order_items.Take(5).ToList();
            foreach (var item in last5)
            {
                idle.Add(await _unitOfWork.Products.GetById(item.Product_id));
            }
            return idle.Take(5).ToList();
        }

        private async Task<List<Product>> GetBestSelling()
        {
            var lis = await _unitOfWork.Request_Items.GetAll();
            var most = lis.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).Take(5).ToList();
            var best = new List<Product>();
            foreach (var item in most)
            {
                best.Add(await _unitOfWork.Products.GetById(item.Product_id));
            }
            return best;
        }

        private async Task<int> GetTodayUsers()
        {
            var users = (await _unitOfWork.Users.GetAll()).ToList().Where(x => x.Created_at.Year.Equals(DateTime.Now.Year) && x.Created_at.Month.Equals(DateTime.Now.Month) && x.Created_at.Day.Equals(DateTime.Now.Day));
            return users.Count();
        }

        private async Task<int> GetTodayOrders()
        {
            var orders = (await _unitOfWork.Requests.GetAll()).ToList().Where(x => x.IsActive && x.Created_at.Year.Equals(DateTime.Now.Year) && x.Created_at.Month.Equals(DateTime.Now.Month) && x.Created_at.Day.Equals(DateTime.Now.Day));
            return orders.Count();
        }

        private List<EarningTable> GetEarningsTotal(List<EarningTable> storeLife, List<EarningTable> wsLife)
        {
            var tabla = new List<EarningTable>();
            foreach (var item in storeLife)
            {
                if (tabla.Exists(x => x.Anno == item.Anno && x.Date.Month == item.Date.Month))
                {
                    int index = tabla.FindIndex(x => x.Anno == item.Anno && x.Date.Month == item.Date.Month);
                    tabla[index].Earning += item.Earning;
                }
                else
                {
                    tabla.Add(new EarningTable() { Anno = item.Anno, Date = item.Date, Earning = item.Earning });
                }
            }
            foreach (var item in wsLife)
            {
                if (tabla.Exists(x => x.Anno == item.Anno && x.Date.Month == item.Date.Month))
                {
                    int index = tabla.FindIndex(x => x.Anno == item.Anno && x.Date.Month == item.Date.Month);
                    tabla[index].Earning += item.Earning;
                }
                else
                {
                    tabla.Add(new EarningTable() { Anno = item.Anno, Date = item.Date, Earning = item.Earning });
                }
            }
            return tabla;
        }

        private async Task<decimal> GetStoreEarnToday()
        {
            var earningTable = await GetRequestsByDate("diario");
            return earningTable.Where(x => x.Date.Day.Equals(DateTime.Now.Day) && x.Date.Month.Equals(DateTime.Now.Month) && x.Date.Year.Equals(DateTime.Now.Year)).ToList().Sum(x => x.Earning);
        }

        private async Task<decimal> GetWSEarnToday()
        {
            var earningTable = await GetServicesByDate("diario");
            return earningTable.Where(x => x.Date.Day.Equals(DateTime.Now.Day) && x.Date.Month.Equals(DateTime.Now.Month) && x.Date.Year.Equals(DateTime.Now.Year)).ToList().Sum(x => x.Earning);
        }

        private async Task<decimal> GetStoreEarnWeek()
        {
            var earningTable = await GetRequestsByDate("general");
            var dia0 = DateTime.Now.Subtract(new TimeSpan((int)DateTime.Now.DayOfWeek, 0, 0, 0));
            return earningTable.Where(x => x.Date.CompareTo(dia0) > 0).ToArray().Sum(x => x.Earning);
        }

        private async Task<decimal> GetWSEarnWeek()
        {
            var earningTable = await GetServicesByDate("general");
            var dia0 = DateTime.Now.Subtract(new TimeSpan((int)DateTime.Now.DayOfWeek, 0, 0, 0));
            return earningTable.Where(x => x.Date.CompareTo(dia0) > 0).ToArray().Sum(x => x.Earning);
        }

        private async Task<decimal> GetStoreEarnTotal()
        {
            var earningTable = await GetRequestsByDate("life");
            return earningTable.Sum(x => x.Earning);
        }

        private async Task<decimal> GetWSEarnTotal()
        {
            var earningTable = await GetServicesByDate("life");
            return earningTable.Sum(x => x.Earning);
        }

        private async Task<List<EarningTable>> GetRequestsByDate(string periodo)
        {
            var tabla = new List<EarningTable>();
            var req_list = await _unitOfWork.Requests.GetAllIncluding();
            if (periodo.Equals("diario"))
            {
                foreach (var item in req_list)
                {
                    if (item.Created_at.Year == DateTime.Now.Year && item.Created_at.Month == DateTime.Now.Month)
                    {
                        var costTotal = item.Request_item_list.Sum(x => x.Product.Cost);
                        if (tabla.Exists(x => x.Date.Day == item.Created_at.Day))
                        {
                            int index = tabla.FindIndex(x => x.Date.Day == item.Created_at.Day);
                            tabla[index].Earning += item.Price - costTotal;
                        }
                        else
                        {
                            tabla.Add(new EarningTable() { Anno = item.Created_at.Year, Date = item.Created_at, Earning = item.Price - costTotal });
                        }
                    }
                }
            }
            else if (periodo == "general")
            {
                foreach (var item in req_list)
                {
                    var costTotal = item.Request_item_list.Sum(x => x.Product.Cost);
                    tabla.Add(new EarningTable() { Anno = item.Created_at.Year, Date = item.Created_at, Earning = item.Price - costTotal });
                }
            }
            else
            {
                foreach (var item in req_list)
                {
                    var costTotal = item.Request_item_list.Sum(x => x.Product.Cost);
                    if (tabla.Exists(x => x.Anno == item.Created_at.Year && x.Date.Month == item.Created_at.Month))
                    {
                        int index = tabla.FindIndex(x => x.Anno == item.Created_at.Year && x.Date.Month == item.Created_at.Month);
                        tabla[index].Earning += item.Price - costTotal;
                    }
                    else
                    {
                        tabla.Add(new EarningTable() { Anno = item.Created_at.Year, Date = item.Created_at, Earning = item.Price - costTotal});
                    }
                }
            }
            return tabla;
        }

        private async Task<List<EarningTable>> GetServicesByDate(string periodo)
        {
            var tabla = new List<EarningTable>();
            var req_list = await _unitOfWork.Services.GetAll();
            if (periodo.Equals("diario"))
            {
                foreach (var item in req_list)
                {
                    if (item.Created_at.Year == DateTime.Now.Year && item.Created_at.Month == DateTime.Now.Month)
                    {
                        if (tabla.Exists(x => x.Date.Day == item.Created_at.Day))
                        {
                            int index = tabla.FindIndex(x => x.Date.Day == item.Created_at.Day);
                            tabla[index].Earning += item.GananciaNeta;
                        }
                        else
                        {
                            tabla.Add(new EarningTable() { Anno = item.Created_at.Year, Date = item.Created_at, Earning = item.GananciaNeta });
                        }
                    }
                }
            }
            else if (periodo == "general")
            {
                foreach (var item in req_list)
                {
                    tabla.Add(new EarningTable() { Anno = item.Created_at.Year, Date = item.Created_at, Earning = item.GananciaNeta });
                }
            }
            else
            {
                foreach (var item in req_list)
                {
                    if (tabla.Exists(x => x.Anno == item.Created_at.Year && x.Date.Month == item.Created_at.Month))
                    {
                        int index = tabla.FindIndex(x => x.Anno == item.Created_at.Year && x.Date.Month == item.Created_at.Month);
                        tabla[index].Earning += item.GananciaNeta;
                    }
                    else
                    {
                        tabla.Add(new EarningTable() { Anno = item.Created_at.Year, Date = item.Created_at, Earning = item.GananciaNeta });
                    }
                }
            }
            return tabla;
        }
    }
}
