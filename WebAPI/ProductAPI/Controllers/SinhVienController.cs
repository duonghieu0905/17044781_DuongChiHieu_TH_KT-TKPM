using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductAPI.Controllers
{
    public class SinhVienController : ApiController
    {
        private SinhVien[] sinhviens = new SinhVien[] { new SinhVien {Id=1,Name="123",DateOfBirth=DateTime.Now,Gender="Nam" },
        new SinhVien {Id=2,Name="123",DateOfBirth=DateTime.Now,Gender="Nam" },
        new SinhVien {Id=3,Name="123",DateOfBirth=DateTime.Now,Gender="Nam" }};
        [Route("Api/Product/GetAllSinhVien")]
        public List<SinhVien> GetAllSinhVien()
        {
            return sinhviens.ToList();
        }
       

        public IHttpActionResult GetSinhVien()
        {
            //var sv = sinhvien.Where(x => x.Id == id).FirstOrDefault();
            //if (sv == null)
            //    return NotFound();
            return Json("12312312312");
        }
        public IHttpActionResult GetAll()
        {
            //var sv = sinhvien.Where(x => x.Id == id).FirstOrDefault();
            //if (sv == null)
            //    return NotFound();
            return Json(sinhviens);
        }


    }
}
