using ShopSimple.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShopSimple.Controller
{
    public class bStatus
    {
        private DBShopSimpleDataContext db = new DBShopSimpleDataContext();

        public bool Add(Status data)
        {
            try
            {
                if (data == null) return false;

                db.Status.InsertOnSubmit(data);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Status data)
        {
            try
            {
                if (data == null) return false;

                var d = db.Status.FirstOrDefault(i => i.StatusCode == data.StatusCode);

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

                var d = db.Status.FirstOrDefault(i => i.StatusCode == code);

                if (d == null) return false;

                db.Status.DeleteOnSubmit(d);
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
            return db.Status.OrderBy(i => i.Name).Select(i => new SelectList { Display = i.Name, Value = i.StatusCode }).ToList();
        }

        public IEnumerable<Status> GetList(string text)
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

        public Status GetDetail(string code)
        {
            return db.Status.FirstOrDefault(i => i.StatusCode == code);
        }

        public bool CheckExists(string code)
        {
            return db.Status.Any(i => i.StatusCode == code);
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

        private IEnumerable<Status> getList(string text)
        {
            text = text?.ToLower();
            var check = string.IsNullOrEmpty(text);

            return check ? db.Status :
                           db.Status.Where(i => i.StatusCode.ToLower().Contains(text) ||
                                                i.Name.ToLower().Contains(text));
        }
    }
}