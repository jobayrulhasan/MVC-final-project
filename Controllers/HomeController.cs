using FinalPorjectDatabaseFirst3.Libs.Utilities;
using FinalPorjectDatabaseFirst3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalPorjectDatabaseFirst3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Login
        private TicketBookingSystemEntities db = new TicketBookingSystemEntities();
        public ActionResult Login()
        {
            return View();
        }

        // POST: HomeController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserName,UserPassword")] TblUser model)
        {
            try
            {
                var oTblUser = db.TblUsers.Where(o => o.UserName == model.UserName && o.UserPassword == model.UserPassword).FirstOrDefault();
                if (oTblUser != null)
                {
                    var listTblUserRole = db.TblUserRoles.Where(o => o.UserID == oTblUser.UserID).ToList();
                    Session["TblUsers"] = oTblUser;
                    Session["TblUserRoles"] = listTblUserRole;
                    if (oTblUser.UserType == UserType.SuperAdmin.ToString())
                    {
                        return RedirectToAction("Index", "Users");
                    }
                    else if (oTblUser.UserType == UserType.GeneralUser.ToString())
                    {
                        return RedirectToAction("Index", "Buses");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("TblUsers");
            return RedirectToAction("Index", "Home");
        }
    }
}