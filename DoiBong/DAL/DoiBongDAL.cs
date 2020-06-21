using DataAccess;
using DataAccess.Model;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoiBongDAL
    {
        private DoiBongDBContext db;
        public DoiBongDAL()
        {
            db = new DoiBongDBContext();
        }
        public List<eDoiBong> GetAllDoiBong()
        {
            List<eDoiBong> lst = new List<eDoiBong>();
            foreach (var item in db.DoiBongs)
            {
                lst.Add(new eDoiBong { madoibong = item.madoibong, tendoibong = item.tendoibong });
            }
            return lst;
        }
        public bool AddDoiBong(eDoiBong e)
        {
            db.DoiBongs.Add(new DoiBong { madoibong = e.madoibong, tendoibong = e.tendoibong });
            db.SaveChanges();
            return true;
        }
        public bool UpdateDoiBong(eDoiBong e)
        {
            var result = db.DoiBongs.Where(x => x.madoibong == e.madoibong).FirstOrDefault();
            if (result is null) return false;
            else
            {
                result.tendoibong = e.tendoibong;
                return true;
            }
               

        }
        public bool DeleteDoiBong(int id)
        {
            var result = db.DoiBongs.Where(x => x.madoibong == id).FirstOrDefault();
            db.DoiBongs.Remove(result);
            return true;
        }
    }
}
