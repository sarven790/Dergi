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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace DergiAboneTakip.Controllers
{

    public static class ExtensionManager
    {
        public static bool IsNumeric(this string value)
        {
            double oReturn = 0;
            return double.TryParse(value, out oReturn);
        }
    }

    [UserFilter]
    public class HomeController : Controller
    {
        Context c = new Context();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int s = 1)
        {
            var degerler = c.dergilers.Include(x=>x.kategori).Where(x => x.Durum == true).ToList().ToPagedList(s, 4);
            return View(degerler);
        }

        public IActionResult Abonelikler(int s = 1)
        {
            var abonelikler = c.abones.Where(x => x.Durum == true).ToList().ToPagedList(s, 4);
            return View(abonelikler);
        }

        
        public IActionResult AboneOl()
        {

            string hp= HttpContext.Request.Query["ID"].ToString();

            string[] hp2 = hp.Split(' ');

            ViewBag.dergiid = hp2[0];

            int i = 2;

            while (hp2[i].IsNumeric() != true)
            {
                i++;
            }

            ViewBag.fiyat = hp2[i];

            i = 1;

            ArrayList deg = new ArrayList();

            while (hp2[i].IsNumeric() != true)
            {
                deg.Add(hp2[i]);
                i++;
            }

            string ad = "";

            for(int j = 0; j < deg.Count; j++)
            {

                ad +=" "+ deg[j];

            }

            ViewBag.dergiad = ad.ToString();

            return View();

        }

        public IActionResult AboneSil(int id)
        {

            var veri = c.abones.Find(id);
            veri.Durum = false;
            c.SaveChanges();

            return Redirect("/Home/Abonelikler");

        }

        [HttpPost]
        public IActionResult AboneOl(AboneTablosu a)
        {

            string hp = HttpContext.Request.Query["ID"].ToString();
            string[] hp2 = hp.Split(' ');
            int dergiid = Convert.ToInt32(hp2[0]);
            int id = (int)HttpContext.Session.GetInt32("id");

            var abonelik = c.abones.FirstOrDefault(x => x.UyeID == id && x.DergiID == dergiid && x.Durum == true);

            if (abonelik == null)
            {
                c.abones.Add(a);
                c.SaveChanges();
            }

            return Redirect("/Home/Index");
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
