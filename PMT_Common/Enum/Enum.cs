using System;
using System.ComponentModel;

namespace PMT_Common.Common
{
    #region Enum Extension
    public static class EnumExtension
    {
        /// <summary>
        /// The get description.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetDescription(this Enum element)
        {
            var type = element.GetType();
            var memberInfo = type.GetMember(Convert.ToString(element));
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return Convert.ToString(element);
        }

        /// <summary>
        /// The get string value
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetStringValuefromEnum(Enum value)
        {
            string output = null;
            var type = value.GetType();
            {
                // Look for our 'StringValueAttribute' in the field's custom attributes
                var fi = type.GetField(Convert.ToString(value));
                var attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    output = attrs[0].Value;
                }
            }

            return output;
        }
    }

    public sealed class StringValueAttribute : Attribute
    {
        /// <summary>
        /// The _value.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public StringValueAttribute(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value
        {
            get { return _value; }
        }
    }
    #endregion

    #region AccessRightEnum
    public enum AccessRightEnum
    {
        [Description("View")]
        View = 1,

        [Description("Add")]
        Add = 2,

        [Description("Edit")]
        Edit = 3,

        [Description("Delete")]
        Delete = 4,

        [Description("Status")]
        Status = 5,
    }
    #endregion

    public enum AuditTrailOperations
    {
        Insert,
        Update,
        Delete,
    }

    public enum MailTemplate
    {
        [Description("Error.html")]
        Error,
        [Description("ForgotPassword.html")]
        ForgotPassword,
        [Description("NewUserAdded.html")]
        NewUserAdded,
    }
}
