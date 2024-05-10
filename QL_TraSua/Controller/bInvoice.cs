using ShopSimple.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bInvoice
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(Invoice data)
        {
            try
            {
                if (data == null) return false;

                db.Invoices.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Invoice data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Invoices.FirstOrDefault(i => i.InvoiceCode == data.InvoiceCode);

                if (d == null) return false;

                d.UserID = data.UserID;
                d.CustomerPhone = data.CustomerPhone;
                d.Date = data.Date;
                d.Total = data.Total;
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

                var d = db.Invoices.FirstOrDefault(i => i.InvoiceCode == code);

                if (d == null) return false;

                db.Invoices.DeleteOnSubmit(d);
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
            return ShopSimple.Library.Lib.CreateKey("HD", true);
        }

        public IEnumerable<Invoice> GetList(string text, DateTime dateFrom, DateTime dateTo, bool isDate,
                                         int priceFrom, int priceTo, bool isPrice)
        {
            try
            {
                var lst = isDate && isPrice ? getList(text, priceFrom, priceTo, dateFrom, dateTo) :
                          isDate ? getList(text, dateFrom, dateTo) :
                          isPrice ? getList(text, priceFrom, priceTo) :
                          getList(text);
                return lst;
            }
            catch
            {
                return null;
            }
        }

        public Invoice GetDetail(string code)
        {
            return db.Invoices.FirstOrDefault(i => i.InvoiceCode == code);
        }

        public bool CheckExists(string code)
        {
            return db.Invoices.Any(i => i.InvoiceCode == code);
        }

        public int GetCount(string text, DateTime dateFrom, DateTime dateTo, bool isDate,
                                         int priceFrom, int priceTo, bool isPrice)
        {
            try
            {
                var lst = isDate && isPrice ? getList(text, priceFrom, priceTo, dateFrom, dateTo) :
                          isDate ? getList(text, dateFrom, dateTo) :
                          isPrice ? getList(text, priceFrom, priceTo) :
                          getList(text);
                return lst.Count();
            }
            catch
            {
                return 0;
            }
        }

        private IEnumerable<Invoice> getList(string text, int priceFrom, int priceTo, DateTime dateFrom, DateTime dateTo)
        {
            return getList(text).Where(i => i.Total >= priceFrom && i.Total <= priceTo && i.Date.Date >= dateFrom.Date && i.Date.Date <= dateTo.Date);
        }

        private IEnumerable<Invoice> getList(string text, int priceFrom, int priceTo)
        {
            return getList(text).Where(i => i.Total >= priceFrom && i.Total <= priceTo);
        }

        private IEnumerable<Invoice> getList(string text, DateTime dateFrom, DateTime dateTo)
        {
            return getList(text).Where(i => i.Date.Date >= dateFrom.Date && i.Date.Date <= dateTo.Date);
        }

        private IEnumerable<Invoice> getList(string text)
        {
            return db.Invoices.Where(i => i.InvoiceCode.ToLower().Contains(text.ToLower()) ||
                                         i.User.Name.ToLower().Contains(text.ToLower()) ||
                                         i.Customer.Phone.Contains(text) ||
                                         i.Customer.Name.ToLower().Contains(text.ToLower()));
        }
    }
}