using ShopSimple.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bCatalog
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(Catalog data)
        {
            try
            {
                if (data == null) return false;

                db.Catalogs.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Catalog data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Catalogs.FirstOrDefault(i => i.CatalogCode == data.CatalogCode);

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

                var d = db.Catalogs.FirstOrDefault(i => i.CatalogCode == code);

                if (d == null) return false;

                db.Catalogs.DeleteOnSubmit(d);
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
            return db.Catalogs.OrderBy(i => i.Name).Select(i => new SelectList { Display = i.Name, Value = i.CatalogCode }).ToList();
        }

        public IEnumerable<Catalog> GetList(string text)
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

        public Catalog GetDetail(string code)
        {
            return db.Catalogs.FirstOrDefault(i => i.CatalogCode == code);
        }

        public bool CheckExists(string code)
        {
            return db.Catalogs.Any(i => i.CatalogCode == code);
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

        private IEnumerable<Catalog> getList(string text)
        {
            text = text?.ToLower();
            var check = string.IsNullOrEmpty(text);

            return check ? db.Catalogs :
                           db.Catalogs.Where(i => i.CatalogCode.ToLower().Contains(text) ||
                                                  i.Name.ToLower().Contains(text));
        }
    }
}