using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShare.Models;
using HomeShareDAL;

namespace HomeShare.Controllers
{
    public class BienController : Controller
    {
        //
        // GET: /Bien/
        public ActionResult Details(int id)
        {
            //Accéder aux details (options) du bien:
            
            
            //cf DevController AdopteUneDev           
            //DetailModel DM = new DetailModel()
            //{
            //    lstCateg = Categories.ChargerToutesLesCategories(),
            //    lstLangs = ITLang.ChargerToutesLesITLang(),
            //    oneDev = Developer.ChargerUnDev(id)
            //};
            DetailsBienModel DetailDuBien = new DetailsBienModel()
            {
                BienConcerne = BienEchange.ChargementBienId(id),
                lstValOptions = OptionsBien.ChargementValOptionsBien(id),
                lstLibOptions = Options.ChargementLibOptions(id),
                Proprietaire = Membre.ChargementMembreBien(id),
                PaysDuMembre = Pays.ChargementPaysMembreBien(id),
                PaysDuBien = Pays.ChargementPaysBien(id),
                ListeAvis = AvisMembreBien.ChargementAvisBien(id),

            };



            return View(DetailDuBien);
        }
	}
}