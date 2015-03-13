using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShareDAL;

namespace HomeShare.Models
{
    public class DetailsBienModel :HomeModel
    {
        //cf adopteUneDev
        //public class DetailModel
        //{
        //    public List<Categories> lstCateg
        //    {
        //        get;
        //        set;
        //    }

        //    public List<ITLang> lstLangs
        //    {
        //        get;
        //        set;
        //    }

        //    public Developer oneDev
        //    {
        //        get;
        //        set;
        //    }
        //}
        //
        public BienEchange BienConcerne
        {
            get;
            set;
        }

        public List<AvisMembreBien> ListeAvis
        {
            get;
            set;
        }

        public List<OptionsBien> lstValOptions
        {
            get;
            set;
        }

        public List<Options> lstLibOptions
        {
            get;
            set;
        }

        public Membre Proprietaire
        {
            get;
            set;
        }

        public Pays PaysDuBien
        {
            get;
            set;
        }

        public Pays PaysDuMembre
        {
            get;
            set;
        }



    }
}