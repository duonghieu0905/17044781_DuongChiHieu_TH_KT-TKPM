using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoiBongBLL
    {
        private DoiBongDAL db;
        public DoiBongBLL()
        {
            db = new DoiBongDAL();
        }
        public List<eDoiBong> GetAllDoiBong()
        {
            return db.GetAllDoiBong();
        }
        public bool AddDoiBong(eDoiBong e)
        {
            return db.AddDoiBong(e);
        }
        public bool UpdateDoiBong(eDoiBong e)
        {
            return db.UpdateDoiBong(e);
        }
        public bool DeleteDoiBong(int id)
        {
            return db.DeleteDoiBong(id);
        }
    }
}
