using DAL;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class CauThuBLL
    {
        private CauThuDAL db;
        public CauThuBLL()
        {
            db = new CauThuDAL();
        }
        public List<eCauThu> GetAllCauThu()
        {
            return db.GetAllCauThu();
        }
        public bool AddCauThu(eCauThu e)
        {
            return db.AddCauThu(e);
        }
        public bool UpdateCauThu(eCauThu e)
        {
            return db.UpdateCauThu(e);
        }
        public bool DeleteCauThu(int id)
        {
            return db.DeleteCauThu(id);
        }
    }
}
