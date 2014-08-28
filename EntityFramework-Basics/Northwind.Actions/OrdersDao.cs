namespace Northwind.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Northwind.Data;

    public static class OrdersDao
    {
        public static IEnumerable<object> GetSales(string region, DateTime from, DateTime to)
        {
            using (var db = new NorthwindEntities())
            {
                var sales = db.Orders
                              .Where(s => s.ShipRegion == region && s.OrderDate >= from && s.OrderDate <= to)
                              .Select(s => new
                              {
                                  ShipName = s.ShipName,
                                  OrderDate = s.OrderDate
                              })
                              .ToList();

                return sales;
            }
        }
    }
}