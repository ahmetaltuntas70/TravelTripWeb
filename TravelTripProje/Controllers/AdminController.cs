using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult iletisim()
        {
            var sorgu = c.İletisims.ToList();
            return View("iletisim", sorgu);

        }
        public ActionResult iletisil(int id)
        {
            var getir = c.İletisims.Find(id);
            c.İletisims.Remove(getir);
            c.SaveChanges();
            return RedirectToAction("iletisim");
        }
        public ActionResult Hakkimizda()
        {
            var getir = c.Hakkimizdas.ToList();
            return View("Hakkimizda", getir);
        }
        public ActionResult HakkimizdaGetir(int id)
        {

            var getir = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", getir);
        }
        public ActionResult HakkimizdaGuncelle(Hakkimizda g)
        {
            var guncelle = c.Hakkimizdas.Find(g.ID);
            guncelle.FotoUrl = g.FotoUrl;
            guncelle.Aciklama = g.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
    }
}