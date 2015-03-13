using HomeShare.Helper;
using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Areas.ZoneMembre.Controllers
{
    public class HomeController : Controller
    {

        //Récupérer Membre
        public ActionResult Index()
        {
            if (MaSession.Login != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        //vue login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //données du membre check BDD
        [HttpPost]
        public ActionResult Login(string tLog, string tPass)
        {
            Membre m = Membre.ChargementMembreMDP(tLog, tPass);


            if(m == null)
            {
                ViewBag.Error = "Veuillez recommencer";
                return View();
            }

            else
            {
                MaSession.Login = m.Login;
                MaSession.Utilisateur = m;

                return RedirectToRoute(new { controller = "Home", action = "Index"});
            }

        }
        //Inscription a inserer ds BDD, l'insertion ne se fait pas :(
        [HttpGet]
        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(string tNom, string tPrenom, string tEmail, int tPays, string tTel, string tLogin, string tPassword)
        {

            Membre m = new Membre();
            m.Nom = tNom;
            m.Prenom = tPrenom;
            m.Email = tEmail;
            m.Pays = tPays;
            m.Telephone = tTel;
            m.Login = tLogin;
            m.Password = tPassword;
            m.Enregistrer();

            return RedirectToRoute(new { area = "ZoneMembre", controller = "Home", action = "Inscription" });
        }

        //Ajouter un bien à la BDD

        //sur base d'ifnews et comme pour inscription ci-dessus:
 
          
        //     [HttpGet]
        //public ActionResult AddNews()
        //{
        //    if (Utils.Login == null)
        //    {
        //        return RedirectToAction("Login");
        //    }
        //return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddNews(News n, HttpPostedFileWrapper Fclient)
        //---------------------------------------
            //    if (Utils.Login == null)
            //    {
                   //return RedirectToAction("Login");
            //    }
            //    if (Fclient != null)
            //    {
            //        n.Picture = Fclient.FileName;
            //        Fclient.SaveAs(@"C:\Users\Mike\Documents\visual studio 2013\Projects\IFNews\IFNews\Content\images\news\" + Fclient.FileName);
            //    }
            //    else
            //    {
            //        n.Picture = "";
            //    }
            //    n.SaveMe();
            //return  RedirectToAction("Index");

        [HttpGet]
        public ActionResult AjouterBien()
        {
            return View();
        }

        [HttpPost]
      public ActionResult AjouterBien(BienEchange bE, HttpPostedFileWrapper Fmembre, string tTitre, string tDescCourte, string tDescLongue, int tNbre, int tPays,
            string tVille, string tRue, string tNumero, string tCodePostal, string tPhoto)
            
        {
            if (MaSession.Login == null)
            {
                return RedirectToAction("Login");
            }
            if (Fmembre != null)
            {
                bE.Titre = tTitre;
                bE.DescCourte = tDescCourte;
                bE.DescLong = tDescLongue;
                bE.NombrePerson = tNbre;
                bE.Pays = tPays;
                bE.Ville = tVille;
                bE.Rue = tRue;
                bE.Numero = tNumero;
                bE.CodePostal = tCodePostal;
                bE.Photo = Fmembre.FileName;
                

                Fmembre.SaveAs(@"Content\img\imgBien\" + Fmembre.FileName);
            }
            else
            {
                bE.Photo = "";
            }





            bE.Enregistrer();
            return RedirectToAction("Index");
        }


        


        // Faire afficher une liste des biens du proprietaire
        //sur base d'ifnews
        public ActionResult ListeBiens()
        {
            if (MaSession.Login == null)
            {
                return RedirectToAction("Login");
            }
            return View(HomeShareDAL.BienEchange.ChargementDesBiens());
        }

        [HttpGet]
        public ActionResult ModifierBien(int id)
        {
            if (MaSession.Login == null)
            {
                return RedirectToAction("Login");
            }
            BienEchange bE = BienEchange.ChargementBienId(id);
            return View(bE);

            //if (Utils.Login == null)
            //{
            //    return RedirectToAction("Login");
            //}
            //News n = News.getOne(id);
            //return View(n);
           
        }
        //modifier le bien de la BDD, il manque la vue qui se baserait sur "ajouter un bien" mais ds laquelle je devrais intégrer les donées de la BDD
        //pour qu'elles apparaissent ds la vue en modifiables
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifierBien(BienEchange b, HttpPostedFileWrapper FMembre)
        {
            if (MaSession.Login == null)
            {
                return RedirectToAction("Login");
            }
            if (FMembre != null)
            {
                b.Photo = FMembre.FileName;
                FMembre.SaveAs(@"Content\img\imgBien\" + FMembre.FileName);
            }
            else
            {
                b.Photo = BienEchange.ChargementBienId(b.IdBien).Photo;
            }
            b.Enregistrer();
            return RedirectToAction("Index");
        }

        //if (Utils.Login == null)
        //{
        //    return RedirectToAction("Login");
        //}
        //if (Fclient != null)
        //{
        //    n.Picture = Fclient.FileName;
        //    Fclient.SaveAs(@"C:\Users\Mike\Documents\visual studio 2013\Projects\IFNews\IFNews\Content\images\news\" + Fclient.FileName);
        //}
        //else
        //{
        //    n.Picture = News.getOne(n.IdNews).Picture;
        //}
        //n.SaveMe();
        //return RedirectToAction("Index");


        //sur base d'ifnews
        [HttpGet]
        public ActionResult SupprimerBien(int id)
        {
            if (MaSession.Login == null)
            {
                return RedirectToAction("Login");
            }
            BienEchange bE = BienEchange.ChargementBienId(id);
            bE.Supprimer();
            return RedirectToAction("ListeBiens");
        }

            //        if (Utils.Login == null)
            //{
            //    return RedirectToAction("Login");
            //}
            //News n = News.getOne(id);
            //n.DeleteMe();
            //return RedirectToAction("ListNews");


        public ActionResult LogOut()
        {
            MaSession.Login = null;
            return RedirectToAction("Index");
        }

	}
}