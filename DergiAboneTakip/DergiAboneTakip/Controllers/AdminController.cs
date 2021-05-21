using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DergiAboneTakip.Filter;
using DergiAboneTakip.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace DergiAboneTakip.Controllers
{

    [UserFilter]
    public class AdminController : Controller
    {

        Context c = new Context();

        public IActionResult AdminIndex(int s = 1)
        {

            int id = (int)HttpContext.Session.GetInt32("id");

            List<UyelerTablosu> tablo = c.uyelers.Where(x => x.ID != id).ToList();

            var degerler = tablo.ToPagedList(s, 4);
            return View(degerler);
        }

        public IActionResult UyePasif(int id) //seçilen üyeler pasif hale getirilir.
        {

            var veri = c.uyelers.Find(id);
            veri.Durum = false;
            c.SaveChanges();

            return Redirect("/Admin/AdminIndex");

        }
        public IActionResult UyeAktif(int id) //seçilen üyeler aktif hale getirilir.
        {

            var veri = c.uyelers.Find(id);
            veri.Durum = true;
            c.SaveChanges();

            return Redirect("/Admin/AdminIndex");

        }

        public IActionResult Kategoriler(int s = 1)
        {

            var degerler = c.kategoris.ToList().ToPagedList(s, 4);
            return View(degerler);

        }

        public IActionResult Dergiler(int s = 1)
        {

            var degerler = c.dergilers.Include(x => x.kategori).ToList().ToPagedList(s, 4);
            return View(degerler);

        }

        [HttpGet]
        public IActionResult DergiEkle()
        {

            List<SelectListItem> degerler = (from i in c.kategoris.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = i.KategoriAdi,
                                                 Value = i.ID.ToString()

                                             }).ToList();

            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public IActionResult DergiEkle(DergilerTablosu d)
        {

            var ktg = c.kategoris.Where(x => x.ID == d.kategori.ID).FirstOrDefault();
            d.kategori = ktg;
            c.dergilers.Add(d);
            c.SaveChanges();

            return Redirect("/Admin/Dergiler");

        }

        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(KategoriTablosu k)
        {

            c.kategoris.Add(k);
            c.SaveChanges();

            return Redirect("/Admin/Kategoriler");

        }

    }
}
