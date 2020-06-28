using System;
using System.Collections.Generic;
using System.Web;

namespace PMT_Helper.Helper
{
    public class SessionHelper
    {
        public static SessionHelper Current
        {
            get
            {
                return (SessionHelper)HttpContext.Current.Session["SessionHelper"];
            }
            set
            {
                HttpContext.Current.Session["SessionHelper"] = value;
            }
        }

        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? 0 : (int)HttpContext.Current.Session["UserId"];
            }

            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static string WelcomeUser
        {
            get
            {
                return HttpContext.Current.Session["WelcomeUser"] == null
                           ? "Guest"
                           : (string)HttpContext.Current.Session["WelcomeUser"];
            }

            set
            {
                HttpContext.Current.Session["WelcomeUser"] = value;
            }
        }

        public static bool IsSuperAdmin
        {
            get
            {
                return HttpContext.Current.Session["IsSuperAdmin"] != null && (bool)HttpContext.Current.Session["IsSuperAdmin"];
            }

            set
            {
                HttpContext.Current.Session["IsSuperAdmin"] = value;
            }
        }

        //public static string ActiveuParentMenuId
        //{
        //    get
        //    {
        //        return Convert.ToString(HttpContext.Current.Session["ActiveuParentMenuId"]);
        //    }

        //    set
        //    {

        //        string currentMenu = HttpContext.Current.Session["ActiveuParentMenuId"] == null ? "0" : Convert.ToString(HttpContext.Current.Session["ActiveuParentMenuId"]);
        //        if (value != "0" && (currentMenu != value))
        //            CommonMethods.ClearSearchFilter();

        //        HttpContext.Current.Session["ActiveuParentMenuId"] = value;
        //        ActiveMiddleMenuId = "0";
        //        ActiveLeftMenuId = "0";
        //        //Pager.PageIndex = 1;
        //    }
        //}

        //public static string ActiveMiddleMenuId
        //{
        //    get
        //    {
        //        return HttpContext.Current.Session["ActiveMiddleMenuId"] == null ? "0" : Convert.ToString(HttpContext.Current.Session["ActiveMiddleMenuId"]);
        //    }

        //    set
        //    {
        //        HttpContext.Current.Session["ActiveMiddleMenuId"] = value;
        //        ActiveLeftMenuId = "0";
        //    }
        //}

        //public static string ActiveLeftMenuId
        //{
        //    get
        //    {
        //        return HttpContext.Current.Session["ActiveLeftMenuId"] == null ? "0" : Convert.ToString(HttpContext.Current.Session["ActiveLeftMenuId"]);
        //    }

        //    set
        //    {
        //        string currentMenu = HttpContext.Current.Session["ActiveLeftMenuId"] == null ? "0" : Convert.ToString(HttpContext.Current.Session["ActiveLeftMenuId"]);
        //        if (value != "0" && (currentMenu != value))
        //            CommonMethods.ClearSearchFilter();

        //        HttpContext.Current.Session["ActiveLeftMenuId"] = value;
        //    }
        //}

        //public static List<UserAccessPermissions_Result> UserAccessPermissions
        //{
        //    get
        //    {
        //        return HttpContext.Current.Session["UserAccessPermissions"] == null ? new List<UserAccessPermissions_Result>() : HttpContext.Current.Session["UserAccessPermissions"] as List<UserAccessPermissions_Result>;
        //    }

        //    set
        //    {
        //        HttpContext.Current.Session["UserAccessPermissions"] = value;
        //    }
        //}

        //public static Dictionary<string, object> SaveSearchFilters
        //{
        //    get
        //    {
        //        return HttpContext.Current.Session["SaveSearchFilters"] == null
        //                   ? new Dictionary<string, object>()
        //                   : (Dictionary<string, object>)HttpContext.Current.Session["SaveSearchFilters"];
        //    }

        //    set
        //    {
        //        HttpContext.Current.Session["SaveSearchFilters"] = value;
        //    }
        //}

        //public static Exception Error
        //{
        //    get
        //    {
        //        return (Exception)HttpContext.Current.Session["Error"];
        //    }

        //    set
        //    {
        //        HttpContext.Current.Session["Error"] = value;
        //    }
        //}

        //public static void RemoveSesstion(string sessionName)
        //{
        //    HttpContext.Current.Session.Remove(sessionName);
        //}
    }
}
