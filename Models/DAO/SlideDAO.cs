using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class SlideDAO
    {
        OnlineShopDbContext db = null;

        public SlideDAO()
        {
            db = new OnlineShopDbContext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.OrderBy(x => x.DisplayOrther).ToList();
        }
    }
}
