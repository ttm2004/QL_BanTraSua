using ShopSimple.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bAdmin
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(Admin data)
        {
            try
            {
                if (data == null) return false;

                db.Admins.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Admin data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Admins.FirstOrDefault(i => i.Username == data.Username);

                if (d == null) return false;

                d.Name = data.Name;
                d.Password = data.Password;
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePassword(string username, string password)
        {
            try
            {
                var d = db.Admins.FirstOrDefault(i => i.Username == username);

                if (d == null) return false;

                d.Password = password;
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username)) return false;

                var d = db.Admins.FirstOrDefault(i => i.Username == username);

                if (d == null) return false;

                db.Admins.DeleteOnSubmit(d);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Admin> GetList()
        {
            try
            {
                return db.Admins;
            }
            catch
            {
                return null;
            }
        }

        public Admin GetDetail(string username)
        {
            return db.Admins.FirstOrDefault(i => i.Username == username);
        }

        public bool CheckExists(string username, string password)
        {
            return db.Admins.Any(i => i.Username == username && i.Password == password);
        }

        public int GetCount()
        {
            try
            {
                return db.Admins.Count();
            }
            catch
            {
                return 0;
            }
        }
    }
}