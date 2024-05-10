using ShopSimple.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bImport
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(Import data)
        {
            try
            {
                if (data == null) return false;

                db.Imports.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Import data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Imports.FirstOrDefault(i => i.ImportCode == data.ImportCode);

                if (d == null) return false;

                d.UserID = data.UserID;
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

                var d = db.Imports.FirstOrDefault(i => i.ImportCode == code);

                if (d == null) return false;

                db.Imports.DeleteOnSubmit(d);
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
            return ShopSimple.Library.Lib.CreateKey("NH", true);
        }

        public IEnumerable<Import> GetList(string text, DateTime dateFrom, DateTime dateTo, bool isDate,
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

        public Import GetDetail(string code)
        {
            return db.Imports.FirstOrDefault(i => i.ImportCode == code);
        }

        public bool CheckExists(string code)
        {
            return db.Imports.Any(i => i.ImportCode == code);
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

        private IEnumerable<Import> getList(string text, int priceFrom, int priceTo, DateTime dateFrom, DateTime dateTo)
        {
            return getList(text).Where(i => i.Total >= priceFrom && i.Total <= priceTo && i.Date.Date >= dateFrom.Date && i.Date.Date <= dateTo.Date);
        }

        private IEnumerable<Import> getList(string text, int priceFrom, int priceTo)
        {
            return getList(text).Where(i => i.Total >= priceFrom && i.Total <= priceTo);
        }

        private IEnumerable<Import> getList(string text, DateTime dateFrom, DateTime dateTo)
        {
            return getList(text).Where(i => i.Date.Date >= dateFrom.Date && i.Date.Date <= dateTo.Date);
        }

        private IEnumerable<Import> getList(string text)
        {
            return db.Imports.Where(i => i.ImportCode.ToLower().Contains(text.ToLower()) ||
                                         i.Admin.Name.ToLower().Contains(text.ToLower()));
        }
    }
}