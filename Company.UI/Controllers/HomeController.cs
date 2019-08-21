using Company.IBLL;
using Company.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.UI.Controllers
{
    public class HomeController : Controller
    {
        private IStaffService StaffService = BLLContainer.Container.Resolve<IStaffService>();
        // GET: Home
        public ActionResult Index()
        {
            List<Staff> list = StaffService.GetModels(p => true).ToList();
            //List<Staff> aa = (from s in list where s.ID > 5 select s).ToList();
            return View(list);
        }
        public ActionResult Add(Staff staff)
        {
            if (StaffService.Add(staff))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Update(Staff staff)
        {
            if (StaffService.Update(staff))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Delete(int Id)
        {
            var staff = StaffService.GetModels(p => p.ID == Id).FirstOrDefault();
            if (StaffService.Delete(staff))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
    }
}