using ShopSimple.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bUser
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(User data)
        {
            try
            {
                if (data == null) return false;

                db.Users.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(User data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Users.FirstOrDefault(i => i.Username == data.Username);

                if (d == null) return false;

                d.Name = data.Name;
                d.Phone = data.Phone;
                d.Address = data.Address;
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
                var d = db.Users.FirstOrDefault(i => i.Username == username);

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

        public bool Delete(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code)) return false;

                var d = db.Users.FirstOrDefault(i => i.Username == code);

                if (d == null) return false;

                db.Users.DeleteOnSubmit(d);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> GetList(string text)
        {
            try
            {
                return getList(text);
            }
            catch
            {
                return null;
            }
        }

        public User GetDetail(string code)
        {
            return db.Users.FirstOrDefault(i => i.Username == code);
        }

        public bool CheckExists(string username, string password)
        {
            return db.Users.Any(i => i.Username == username && i.Password == password);
        }

        public bool CheckExists(string username)
        {
            return db.Users.Any(i => i.Username == username);
        }

        public int GetCount(string text)
        {
            try
            {
                return getList(text).Count();
            }
            catch
            {
                return 0;
            }
        }

        private IEnumerable<User> getList(string text)
        {
            return string.IsNullOrEmpty(text) ? db.Users :
                                                db.Users.Where(i => i.Username.Contains(text) ||
                                                                    i.Name.ToLower().Contains(text.ToLower()) ||
                                                                    i.Phone.Contains(text) ||
                                                                    i.Address.ToLower().Contains(text.ToLower()));
        }
    }
}