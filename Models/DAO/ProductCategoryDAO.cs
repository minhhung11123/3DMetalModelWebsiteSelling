﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductCategoryDAO
    {
        OnlineShopDbContext db = null;

        public ProductCategoryDAO()
        {
            db = new OnlineShopDbContext();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.OrderBy(x => x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }
}
