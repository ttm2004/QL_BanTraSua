using ShopSimple.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bSupplier
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(Supplier data)
        {
            try
            {
                if (data == null) return false;

                db.Suppliers.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Supplier data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Suppliers.FirstOrDefault(i => i.SupplierCode == data.SupplierCode);

                if (d == null) return false;

                d.Name = data.Name;
                d.Email = data.Email;
                d.Phone = data.Phone;
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

                var d = db.Suppliers.FirstOrDefault(i => i.SupplierCode == code);

                if (d == null) return false;

                db.Suppliers.DeleteOnSubmit(d);
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
            return db.Suppliers.OrderBy(i => i.Name).Select(i => new SelectList { Display = i.Name, Value = i.SupplierCode }).ToList();
        }

        public IEnumerable<Supplier> GetList(string text)
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

        public Supplier GetDetail(string code)
        {
            return db.Suppliers.FirstOrDefault(i => i.SupplierCode == code);
        }

        public bool CheckExists(string code)
        {
            return db.Suppliers.Any(i => i.SupplierCode == code);
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

        private IEnumerable<Supplier> getList(string text)
        {
            return string.IsNullOrEmpty(text) ? db.Suppliers :
                                                db.Suppliers.Where(i => i.SupplierCode.ToLower().Contains(text.ToLower()) ||
                                                                        i.Name.ToLower().Contains(text.ToLower()) ||
                                                                        i.Email.Contains(text) ||
                                                                        i.Phone.Contains(text));
        }
    }
}