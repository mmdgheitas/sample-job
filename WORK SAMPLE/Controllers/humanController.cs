using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WORK_SAMPLE.Controllers
{
    public class humanController : Controller
    {
        // GET: human
        public ActionResult Index()
        {
            return View();
        }

        Models.human h1 = new Models.human();
        Models.db db = new Models.db();
        public ActionResult send(Models.human h)
        {
            foreach (var i in db.human)
            {
                if (i.name == h.name && i.pass == h.pass)
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            
            
                h1.name = h.name;
                h1.family = h.family;
                h1.pass = h.pass;
                h1.user = h.user;
                db.human.Add(h1);
                db.SaveChanges();
                return Json(1, JsonRequestBehavior.AllowGet);
        }              
        public ActionResult recive(string name ,int pass)
        {
           
            var q = from i in db.human where (i.user == name && i.pass == pass) select i;          
            if (q.Count() >= 1)
            {
                connect(q.Single().name , q.Single().family);
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            return Json(false,JsonRequestBehavior.AllowGet);
        }
        public void connect(string n,string m)
        {
            Models.S x = new Models.S();
            x.name = n;
            x.family = m;
            db.admin.Add(x);
            db.SaveChanges();
            
        }
        public ActionResult nameback()
        {
            
           var a =from i in db.admin select i.id;
           int g = a.Max();
            var y = from i in db.admin where (i.id == g) select i.name;
            //string y = a.Single().name;
            return Json(y, JsonRequestBehavior.AllowGet);
        }
        public ActionResult save(string nzr)
        {
            Models.S x = new Models.S();
            x.date = nzr;
            db.admin.Add(x);
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        //public void close()
        //{
            
        //}
    }
}