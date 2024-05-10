using ShopSimple.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bImportDetail
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(ImportDetail data)
        {
            try
            {
                if (data == null) return false;

                db.ImportDetails.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ImportDetail data)
        {
            try
            {
                if (data == null) return false;

                var d = db.ImportDetails.FirstOrDefault(i => i.ImportID == data.ImportID && i.ProductID == data.ProductID);

                if (d == null) return false;

                d.ProductID = data.ProductID;
                d.Quantity = data.Quantity;
                d.Price = data.Price;
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string invoiceCode, string productCode)
        {
            try
            {
                if (string.IsNullOrEmpty(invoiceCode) || string.IsNullOrEmpty(productCode)) return false;

                var d = db.ImportDetails.FirstOrDefault(i => i.ImportID == invoiceCode && i.ProductID == productCode);

                if (d == null) return false;

                db.ImportDetails.DeleteOnSubmit(d);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<ImportDetail> GetList(string invoiceCode)
        {
            try
            {
                return db.ImportDetails.Where(i => i.ImportID == invoiceCode);
            }
            catch
            {
                return null;
            }
        }

        public ImportDetail GetDetail(string code)
        {
            return db.ImportDetails.FirstOrDefault(i => i.ImportID == code);
        }

        public bool CheckExists(string code)
        {
            return db.ImportDetails.Any(i => i.ImportID == code);
        }

        public int GetCount(string invoiceCode)
        {
            try
            {
                return db.ImportDetails.Count(i => i.ImportID == invoiceCode);
            }
            catch
            {
                return 0;
            }
        }

        public int GetQuantity(string invoiceCode)
        {
            try
            {
                return db.ImportDetails.Where(i => i.ImportID == invoiceCode).Sum(i => i.Quantity);
            }
            catch
            {
                return 0;
            }
        }
    }
}