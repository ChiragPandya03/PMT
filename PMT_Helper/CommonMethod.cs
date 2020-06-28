using PMT_Common.Common;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;


namespace PMT_Helper.Helper
{
    public static class CommonMethods
    {
        public static string SiteRootPathUrl
        {
            get
            {
                string msRootUrl;
                if (HttpContext.Current.Request.ApplicationPath != null && string.IsNullOrEmpty(HttpContext.Current.Request.ApplicationPath.Split('/')[1]))
                {
                    msRootUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host +
                                ":" +
                                HttpContext.Current.Request.Url.Port;
                }
                else
                {
                    msRootUrl = HttpContext.Current.Request.ApplicationPath;
                }

                return msRootUrl;
            }
        }

        public static string ShowAlertMessage(string url, string message)
        {
            message = Regex.Replace(message, @"[^\d\w\s\.\,\""]", " ").Replace("\r\n", " ");
            return @"<script type='text/javascript' language='javascript'>$(function() { showMessage('" + url + "',' " + message + "') ; })</script>";
        }

        public static string ShowAlertMessage(string message)
        {
            message = Regex.Replace(message, @"[^\d\w\s\.\,]", " ").Replace("\r\n", " ");
            var strString = @"<script type='text/javascript' language='javascript'>$(function() { showMessageOnly(' " + message + "') ; })</script>";
            return strString;
        }

        public static string CustomJavascriptCall(string message)
        {
            var strString = @"<script type='text/javascript' language='javascript'>" + message + "</script>";
            return strString;
        }

        //public static StringBuilder GetMailTemplate(MailTemplate template)
        //{
        //    string filePath = HttpContext.Current.Server.MapPath("~/MailTemplate/" + template.GetDescription());
        //    if (File.Exists(filePath))
        //    {
        //        StreamReader sr = new StreamReader(filePath);
        //        StringBuilder mailContent = new StringBuilder(sr.ReadToEnd());
        //        sr.Close();
        //        return mailContent;
        //    }
        //    return null;
        //}

        //public static string GetMonthName(int periods)
        //{
        //    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(periods);
        //}

        //public static void SendMail(string mailTo, string subject, string content, string mailFrom = "", bool ishtml = true, string bcc = "", string cc = "", string attachmentFileName = "")
        //{
        //    Email.MailServerHost = SettingConfig.MailServerHost;
        //    Email.MailServerPassword = SettingConfig.MailServerPassword;
        //    Email.SendMail(
        //        (!string.IsNullOrEmpty(mailFrom)) ? mailFrom : SettingConfig.MailServerFromMail,
        //        mailTo, "tatvasoft | " + subject,
        //        content,
        //        ishtml, bcc, cc, attachmentFileName);
        //}

        //public static object GetSearchFilterFromDictionary(string controllerName)
        //{
        //    var obj = SessionHelper.SaveSearchFilters;
        //    if (!obj.ContainsKey(controllerName))
        //    {
        //        return null;
        //    }

        //    object model;
        //    obj.TryGetValue(controllerName, out model);
        //    return model;
        //}

        //public static void AddSearchFilterInDictionary(string controllerName, object model)
        //{
        //    var obj = SessionHelper.SaveSearchFilters;
        //    obj.Clear();
        //    obj.Add(controllerName, model);
        //    SessionHelper.SaveSearchFilters = obj;
        //}

        //public static void ClearSearchFilter()
        //{
        //    var obj = SessionHelper.SaveSearchFilters;
        //    obj.Clear();
        //    SessionHelper.SaveSearchFilters = obj;
        //}
    }
}
