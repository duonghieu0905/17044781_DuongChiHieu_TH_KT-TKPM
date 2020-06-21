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
    public class CauThuDAL
    {
        private DoiBongDBContext db;
        public CauThuDAL()
        {
            db = new DoiBongDBContext();
        }
        public List<eCauThu> GetAllCauThu()
        {
            List<eCauThu> list = new List<eCauThu>();
            foreach (var item in db.CauThus)
            {
                list.Add(new eCauThu { email = item.email, iddoibong = item.iddoibong, macauthu = item.macauthu, sodt = item.sodt, tencauthu = item.tencauthu });
            }
            return list;
        }
        public bool AddCauThu(eCauThu e)
        {
            CauThu cauthu = new CauThu { tencauthu = e.tencauthu, email = e.email, iddoibong = e.iddoibong, macauthu = e.macauthu, sodt = e.sodt };
            db.CauThus.Add(cauthu);
            db.SaveChanges();
            return true;
        }
        public bool UpdateCauThu(eCauThu e)
        {
            var result = db.CauThus.Where(x => x.macauthu.Equals(e.macauthu)).FirstOrDefault();
            if (result is null)
                return false;
            else
            {
                result.iddoibong = e.iddoibong;
                result.sodt = e.sodt;
                result.tencauthu = e.tencauthu;
                result.email = e.email;
                db.SaveChanges();
                return true;
            }
        }
        public bool DeleteCauThu(int id)
        {
            var result = db.CauThus.Where(x => x.macauthu == id).FirstOrDefault();
            db.CauThus.Remove(result);
            db.SaveChanges();
            return true;
        }
    }
}
