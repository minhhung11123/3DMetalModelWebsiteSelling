using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDAO
    {
        OnlineShopDbContext db = null;

        public OrderDAO()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }

        public List<Order> ListAll()
        {
            return db.Orders.ToList();
        }

        public bool confirm(long id)
        {
            try
            {
                var order = db.Orders.Find(id);
                order.Status = 1;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
