using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PMT_Common.Common
{
    public static class CommonHelper
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

        public static Dictionary<int, string> TitleLookup
        {
            get
            {
                return new Dictionary<int, string>
                {
                    { 1, "Mr" },
                    { 2, "Miss" },
                    { 3, "Mrs" },
                };
            }
        }

        public static string GetErrorMessage(Exception ex, bool getStactRetrace = true)
        {
            try
            {
                var errorMessage = string.Empty;
                if (ex == null) return errorMessage;
                errorMessage = ex.Message;
                if (ex.InnerException != null)
                    errorMessage += Environment.NewLine + GetErrorMessage(ex.InnerException, getStactRetrace);
                if (getStactRetrace)
                    errorMessage += Environment.NewLine + ex.StackTrace;

                errorMessage = errorMessage.Replace("An error occurred while updating the entries. See the inner exception for details.", "");
                return errorMessage;
            }
            catch
            {
                return ex != null ? ex.Message : string.Empty;
            }
        }

        public static string SerializeEntity<T>(T entity)
        {
            if (entity == null) return "";


            try
            {
                // Get list of object properties
                string message = "";
                PropertyInfo[] properties = typeof(T).GetProperties();
                for (int j = 0; j < properties.Count(); j++)
                {
                    if (properties[j].CanWrite == false) continue;

                    if (properties[j].PropertyType.BaseType != null && properties[j].PropertyType.BaseType.FullName != null)
                    {
                        if (properties[j].PropertyType.BaseType.FullName.Contains(".EntityReference")) continue;
                        if (properties[j].PropertyType.BaseType.FullName.Contains(".EntityObject")) continue;
                        if (properties[j].PropertyType.BaseType.FullName.Contains(".RelatedEnd")) continue;
                        if (properties[j].PropertyType.BaseType.FullName.Contains(".EntityReference")) continue;
                        if (properties[j].PropertyType.BaseType.FullName.Contains(".EntityObject")) continue;
                        if (properties[j].PropertyType.BaseType.FullName.Contains(".RelatedEnd")) continue;
                    }


                    if (properties[j].Name.Equals("Errors")) continue;
                    if (properties[j].Name.Equals("EntityKey")) continue;
                    if (properties[j].CanWrite == false) continue;

                    if (properties[j].Name.Equals("Errors")) continue;
                    if (properties[j].Name.Equals("EntityKey")) continue;

                    if ((properties[j].PropertyType).FullName != null)
                    {
                        if ((properties[j].PropertyType).FullName.Contains("DataLayer.Data.SelfTracking.")) continue;
                        if ((properties[j].PropertyType).FullName.Contains("DataLayer.Entity.")) continue;
                        if ((properties[j].PropertyType).FullName.Contains("System.Collections.Generic.List")) continue;
                        if ((properties[j].PropertyType).FullName.Contains("PropertyPicture")) continue;
                        if ((properties[j].PropertyType).FullName.Contains("RelationshipList")) continue;
                        if ((properties[j].PropertyType).FullName.Contains("ReleaseReasonList")) continue;
                    }


                    if (properties[j].Name.Equals("BrokenRules")) continue;
                    if (properties[j].Name.Equals("ObjectBrokenRules")) continue;
                    if (properties[j].Name.Equals("PropertyBrokenRules")) continue;



                    var info = properties[j].GetValue(entity, null);

                    if (Convert.ToString(info).Trim() == "System.Web.Mvc.SelectList") continue;
                    if (Convert.ToString(info).Trim() == "System.Collections.Generic.List") continue;

                    string columnValue;
                    if (info == null)
                    {
                        columnValue = " ";
                    }
                    else
                    {
                        if (info.GetType().FullName == "System.Boolean")
                            columnValue = (bool)info ? "1" : "0";
                        else
                            columnValue = Convert.ToString(info).Trim();

                    }

                    if (info == null || info.GetType().FullName == "System.Byte[]")
                        continue;

                    message += properties[j].Name + " : ";

                    columnValue = columnValue.Replace(",", ", ");
                    message += columnValue + ", " + Environment.NewLine;
                }
                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
