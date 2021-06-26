using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Models.EF;

namespace Models.DAO
{
    public class ProductDAO
    {
        OnlineShopDbContext db = null;

        public ProductDAO()
        {
            db = new OnlineShopDbContext();
        }

        public List<Product> ListAll()
        {
            return db.Products.ToList();
        }

        public List<Product> ListProductHomeTop(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListProductHomeBot(int top)
        {
            return db.Products.OrderBy(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListProduct3(long id)
        {
            return db.Products.SqlQuery("Select top 3 * from Product where CategoryID = @id", new SqlParameter("@id", id)).ToList();
        }

        public List<Product> ListProduct6(long id)
        {
            return db.Products.SqlQuery("Select top 6 * from Product where CategoryID = @id", new SqlParameter("@id", id)).ToList();
        }

        public List<Product> ListProduct9(long id)
        {
            return db.Products.SqlQuery("Select top 9 * from Product where CategoryID = @id", new SqlParameter("@id", id)).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        public int Create(string Name, string Code, string MetaTitle, string Description, string Image, Decimal? Price, Decimal? PromotionPrice, bool? IncludedVAT, int? Quantity, long? CategoryID, string Detail, DateTime? CreatedDate, string CreatedBy, string MetaKeywords, string MetaDescriptions, bool? Status)
        {
            object[] parameters =
            {
                new SqlParameter("@Name", Name),
                new SqlParameter("@Code", Code),
                new SqlParameter("@MetaTitle", MetaTitle),
                new SqlParameter("@Description", Description),
                new SqlParameter("@Image", Image),
                new SqlParameter("@Price", Price),
                new SqlParameter("@PromotionPrice", PromotionPrice),
                new SqlParameter("@IncludeVAT", IncludedVAT),
                new SqlParameter("@Quantity", Quantity),
                new SqlParameter("@CategoryID", CategoryID),
                new SqlParameter("@Detail", Detail),
                new SqlParameter("@CreatedDate", CreatedDate),
                new SqlParameter("@CreatedBy", CreatedBy),
                new SqlParameter("@MetaKeywords", MetaKeywords),
                new SqlParameter("@MetaDescriptions", MetaDescriptions),
                new SqlParameter("@Status", Status)
            };
            int res = db.Database.ExecuteSqlCommand("Sp_Product_Insert @Name, @Code, @MetaTitle, @Description, @Image, @Price, @PromotionPrice, @IncludeVAT, @Quantity, @CategoryID, @Detail, @CreatedDate, @CreatedBy, @MetaKeywords, @MetaDescriptions, @Status", parameters);
            return res;
        }

        public long Edit(long id, Product entity)
        {
            try
            {
                var res = db.Products.SingleOrDefault(x => x.ID == entity.ID);
                if (res != null)
                {
                    db.Products.AddOrUpdate(entity);
                    db.SaveChanges();
                }
                return entity.ID;
            }
            catch
            {
                return 0;
            }
        }
    }
}
