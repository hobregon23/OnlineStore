using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class Statistic
    {
        public decimal StoreEarnToday { get; set; }
        public decimal StoreEarnWeek { get; set; }
        public decimal StoreEarnTotal { get; set; }
        public decimal WorkShopEarnToday { get; set; }
        public decimal WorkShopEarnWeek { get; set; }
        public decimal WorkShopEarnTotal { get; set; }
        public int UsersToday { get; set; }
        public List<Product> BestSellingProducts { get; set; }
        public List<Product> IdleProducts { get; set; }
        public int OrdersToday { get; set; }
        public List<EarningTable> EarningsStoreLife { get; set; }
        public List<EarningTable> EarningsStoreDaily { get; set; }
        public List<EarningTable> EarningsWSLife { get; set; }
        public List<EarningTable> EarningsWSDaily { get; set; }
        public List<EarningTable> EarningsTotal { get; set; }
    }
}
