using System;
using System.Configuration;

namespace PMT_Helper.Helper
{
    public class Helpers
    {
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["RDS_USERNAME"];
            string password = appConfig["RDS_PASSWORD"];
            string hostname = appConfig["RDS_HOSTNAME"];
            string port = appConfig["RDS_PORT"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
    public class TrimModelBinder //: DefaultModelBinder
    {
        //// <summary>
        //// The set property.
        //// </summary>
        //// <param name="controllerContext">
        //// The controller context.
        //// </param>
        //// <param name="bindingContext">
        //// The binding context.
        //// </param>
        //// <param name="propertyDescriptor">
        //// The property descriptor.
        //// </param>
        //// <param name="value">
        //// The value.
        //// </param>
        //protected override void SetProperty(
        //    ControllerContext controllerContext,
        //    ModelBindingContext bindingContext,
        //    System.ComponentModel.PropertyDescriptor propertyDescriptor,
        //    object value)
        //{
        //    if (propertyDescriptor.PropertyType == typeof(string))
        //    {
        //        var stringValue = (string)value;
        //        if (!string.IsNullOrEmpty(stringValue))
        //        {
        //            stringValue = stringValue.Trim();
        //        }

        //        value = stringValue;
        //    }

        //    base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        //}
    }

    public class DateTimeModelBinder //: IModelBinder
    {
    //    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    //    {
    //        var date = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;

    //        if (String.IsNullOrEmpty(date))
    //            return null;

    //        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, bindingContext.ValueProvider.GetValue(bindingContext.ModelName));
    //        try
    //        {
    //            return DateTime.Parse(date);
    //        }
    //        catch (Exception)
    //        {
    //            bindingContext.ModelState.AddModelError(bindingContext.ModelName, String.Format("\"{0}\" is invalid.", bindingContext.ModelName));
    //            return null;
    //        }
    //    }
    }
}
