using ShopSimple.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bCustomer
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(Customer data)
        {
            try
            {
                if (data == null) return false;

                db.Customers.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Customer data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Customers.FirstOrDefault(i => i.Phone == data.Phone);

                if (d == null) return false;

                d.Name = data.Name;
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

                var d = db.Customers.FirstOrDefault(i => i.Phone == code);

                if (d == null) return false;

                db.Customers.DeleteOnSubmit(d);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<SelectList> Select()
        {
            return db.Customers.OrderBy(i => i.Name).Select(i => new SelectList { Display = i.Phone, Value = i.Phone }).ToList();
        }

        public IEnumerable<Customer> GetList(string text)
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

        public Customer GetDetail(string code)
        {
            return db.Customers.FirstOrDefault(i => i.Phone == code);
        }

        public bool CheckExists(string code)
        {
            return db.Customers.Any(i => i.Phone == code);
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

        private IEnumerable<Customer> getList(string text)
        {
            var check = string.IsNullOrEmpty(text);

            return check ? db.Customers :
                           db.Customers.Where(i => i.Phone.Contains(text) ||
                                                   i.Name.ToLower().Contains(text.ToLower()));
        }
    }
}