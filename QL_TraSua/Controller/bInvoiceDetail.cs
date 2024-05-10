using ShopSimple.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bInvoiceDetail
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(InvoiceDetail data)
        {
            try
            {
                if (data == null) return false;

                db.InvoiceDetails.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(InvoiceDetail data)
        {
            try
            {
                if (data == null) return false;

                var d = db.InvoiceDetails.FirstOrDefault(i => i.InvoiceID == data.InvoiceID && i.ProductID == data.ProductID);

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

                var d = db.InvoiceDetails.FirstOrDefault(i => i.InvoiceID == invoiceCode && i.ProductID == productCode);

                if (d == null) return false;

                db.InvoiceDetails.DeleteOnSubmit(d);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<InvoiceDetail> GetList(string invoiceCode)
        {
            try
            {
                return db.InvoiceDetails.Where(i => i.InvoiceID == invoiceCode);
            }
            catch
            {
                return null;
            }
        }

        public InvoiceDetail GetDetail(string code)
        {
            return db.InvoiceDetails.FirstOrDefault(i => i.InvoiceID == code);
        }

        public bool CheckExists(string code)
        {
            return db.InvoiceDetails.Any(i => i.InvoiceID == code);
        }

        public bool CheckExistsProduct(string codeProduct)
        {
            return db.InvoiceDetails.Any(i => i.ProductID == codeProduct);
        }

        public int GetCount(string invoiceCode)
        {
            try
            {
                return db.InvoiceDetails.Count(i => i.InvoiceID == invoiceCode);
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
                return db.InvoiceDetails.Where(i => i.InvoiceID == invoiceCode).Sum(i => i.Quantity);
            }
            catch
            {
                return 0;
            }
        }

    }
}