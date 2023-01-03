using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context context = new Context();

        public ActionResult Index()
        {
            //Toplam Kategori Sayısı
            var categoryvalues = cm.CountCategory();
            ViewBag.CategoryCount = categoryvalues;

            //Başlık Tablosunda "Yazılım" Kategorisine Ait Başlıklar
            //17.Id yazılım kategorisi
            var baslik = context.Headings.Count(x => x.CategoryID == 17);
            ViewBag.baslikyazilim = baslik;
            //Yazar adında 'a' harfi geçen yazar sayısı
            var writername = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.WriterNameHasA = writername;
            //En Fazla Başlığa Sahip Kategori Adı
            var categoryName = context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.MaxCategoryName = categoryName;
            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var True = context.Categories.Count(x => x.CategoryStatus == true);
            var False = context.Categories.Count(x => x.CategoryStatus == false);
            var fark = True - False;
            ViewBag.Fark = fark;

            return View();
        }
    }
}