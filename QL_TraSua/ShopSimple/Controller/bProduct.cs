using ShopSimple.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bProduct
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(Product data)
        {
            try
            {
                if (data == null) return false;

                db.Products.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Product data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Products.FirstOrDefault(i => i.ProductCode == data.ProductCode);

                if (d == null) return false;

                d.Name = data.Name;
                d.Image = data.Image;
                d.CatalogID = data.CatalogID;
                d.SupplierID = data.SupplierID;
                d.Amount = data.Amount;
                d.Price = data.Price;
                d.StatusID = data.StatusID;
                d.CreateDate = data.CreateDate;
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAmount(string code, int amount, bool isAdd)
        {
            try
            {
                if (string.IsNullOrEmpty(code)) return false;

                var d = db.Products.FirstOrDefault(i => i.ProductCode == code);

                if (d == null) return false;

                var t = isAdd ? Convert.ToInt32(amount) + Convert.ToInt32(d.Amount) : Convert.ToInt32(d.Amount) - Convert.ToInt32(amount);

                d.Amount = t;

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

                var d = db.Products.FirstOrDefault(i => i.ProductCode == code);

                if (d == null) return false;

                db.Products.DeleteOnSubmit(d);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string CreateKey()
        {
            return ShopSimple.Library.Lib.CreateKey("SP", true);
        }

        public IEnumerable<Product> GetList(string text)
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

        public Product GetDetail(string code)
        {
            return db.Products.FirstOrDefault(i => i.ProductCode == code);
        }

        public bool CheckExists(string code)
        {
            return db.Products.Any(i => i.ProductCode == code);
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

        private IEnumerable<Product> getList(string text)
        {
            text = text?.ToLower();
            var check = string.IsNullOrEmpty(text);

            return check ? db.Products :
                           db.Products.Where(i => i.ProductCode.ToLower().Contains(text) ||
                                                  i.Name.ToLower().Contains(text) ||
                                                  i.Catalog.Name.ToLower().Contains(text) ||
                                                  i.Supplier.Name.ToLower().Contains(text));
        }
    }
}