using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShare.Helper
{
    public static class MaSession
    {
        public static string Login
        {
            get
            {
                if (HttpContext.Current.Session["Login"] != null) return HttpContext.Current.Session["Login"].ToString();
                else return null;
            }

            set { HttpContext.Current.Session["Login"] = value; }
        }

        public static Membre Utilisateur
        {
            get { return (Membre)HttpContext.Current.Session["Utilisateur"]; }
            set { HttpContext.Current.Session["Utilisateur"] = value; }
        }
        //cf ifNews
        //public static class Utils
        //{
        //    public static string Login
        //    {
        //        get
        //        {
        //            if (HttpContext.Current.Session["Login"] != null) return HttpContext.Current.Session["Login"].ToString();
        //            else return null;
        //        }

        //        set { HttpContext.Current.Session["Login"] = value; }
        //    }

        //}


    }
}