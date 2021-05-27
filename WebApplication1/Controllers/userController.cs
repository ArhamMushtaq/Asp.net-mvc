using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class userController : Controller
    {
        // GET: user
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [ActionName("Login")]
        [HttpPost]
        public ActionResult Login(User user)
        {

            var obj = DBManager.Validate(user.textlogin, user.textpassword);
            if (obj != null)
            {
                Session["login"] = user.textlogin;

                Session["isadmin"] = obj.IsAdmin;

                return Redirect("~/Home/Show");
            }
            else
            {
                ViewBag.Msg = "Invalid User";
 
                ViewBag.login = user.textlogin;
            }
            // String login = Request["textlogin"];
            //String password = Request["textpassword"];

            // String login1 = Request.Form["textlogin"];
            //String Password1 = Request.Form["textpassword"];


            return View("Login");
        }
        public ActionResult logout()
        {
            Session["login"] = null;
            Session.Abandon();
            return Redirect("~/user/login");
        }
    }
}