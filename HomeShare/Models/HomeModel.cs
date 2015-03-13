using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShareDAL;

namespace HomeShare.Models
{
    public class HomeModel
    {
        //cf AdopteUneDev
        //public List<Categories> lstCateg
        //{
        //    get;
        //    set;
        //}

        //public List<ITLang> lstLangs
        //{
        //    get;
        //    set;
        //}

        //public List<Developer> lstDev
        //{
        //    get;
        //    set;
        //}
        public List<BienEchange> lstBiens
        {
            get;
            set;
        }

        public List<Membre> lstMembres
        {
            get;
            set;
        }

        public List<Pays> lstPays
        {
            get;
            set;
        }

        public List<AvisMembreBien> LstAvis
        {
            get;
            set;
        }


    }
}