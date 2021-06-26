using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class AccountDAO
    {
        OnlineShopDbContext db = null;

        public AccountDAO()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Account entity)
        {
            entity.Type = false;
            db.Accounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public long InsertAd(Account entity)
        {
            entity.Type = true;
            db.Accounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Account GetByName(string userName)
        {
            return db.Accounts.SingleOrDefault(x => x.UserName == userName);
        }

        public bool Login(string userName, string passWord)
        {
            var rs = db.Accounts.Count(x => x.UserName == userName && x.Password == passWord);
            if (rs > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginAd(string userName, string passWord)
        {
            var rs = db.Accounts.Count(x => x.UserName == userName && x.Password == passWord && x.Type == true);
            if (rs > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FindUser(string userName)
        {
            var rs = db.Accounts.Count(x => x.UserName == userName);
            if (rs > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Account> ListAll()
        {
            return db.Accounts.ToList();
        }

        public Account ViewDetail(long id)
        {
            return db.Accounts.Find(id);
        }

        public long Edit(long id, Account entity)
        {
            try
            {
                var res = db.Accounts.SingleOrDefault(x => x.ID == entity.ID);
                if (res != null)
                {
                    db.Accounts.AddOrUpdate(entity);
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
