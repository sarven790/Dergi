using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DergiAboneTakip.Models;
using Microsoft.AspNetCore.Http;

namespace DergiAboneTakip.Controllers
{
    public class AccountController : Controller
    {

        Context c = new Context();

        [HttpGet]
        public IActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UyeOl(UyelerTablosu u)
        {

            c.Add(u);
            c.SaveChanges();

            return RedirectToAction("UyeGiris");
        }
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return Redirect("/Account/UyeGiris");

        }
        public IActionResult UyeGiris()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();

        }
        public IActionResult Login(string KulAdi, string Sifre)
        {

            var user = c.uyelers.FirstOrDefault(x => x.KulAdi.Equals(KulAdi) && x.Sifre.Equals(Sifre) && x.Durum.Equals(true));

            if (user != null)
            {
                if (user.Yetki == 1)
                {
                    HttpContext.Session.SetInt32("id", user.ID);
                    return Redirect("/Admin/AdminIndex?id=" + user.ID);
                }
                else
                {
                    HttpContext.Session.SetInt32("id", user.ID);
                    return Redirect("/Home/Index?id=" + user.ID);
                }
               
            }

            return Redirect("/Account/UyeGiris");

        }
    }
}
