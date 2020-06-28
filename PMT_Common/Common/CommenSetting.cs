namespace PMT_Common.Common
{
    using System.Collections.Generic;
    public class CommenSetting
    {
        public const string Select = "Select";
        public static readonly Dictionary<string, object> GridStyle400WithCentre = new Dictionary<string, object> { { "align", "center" }, { "width", "400px" }, { "valign", "middle" } };
        public static readonly Dictionary<string, object> GridStyle400 = new Dictionary<string, object> { { "width", "400px" } };
        public static readonly Dictionary<string, object> GridStyle300 = new Dictionary<string, object> { { "width", "300px" } };
        public static readonly Dictionary<string, object> GridStyle300WithCentre = new Dictionary<string, object> {{"align", "center"}, {"width", "300px"}, {"valign", "middle"}};

        public static readonly Dictionary<string, object> GridStyle100WithCentre = new Dictionary<string, object> {{"align", "center"}, {"width", "100px"}, {"valign", "middle"}, {"style", "text-align:center"}};
        public static readonly Dictionary<string, object> GridStyle150WithCentre = new Dictionary<string, object> { { "align", "center" }, { "width", "150px" }, { "valign", "middle" } };
        public static readonly Dictionary<string, object> GridStyle100 = new Dictionary<string, object> { { "width", "100px" } };
        public static readonly Dictionary<string, object> GridStyle200 = new Dictionary<string, object> { { "width", "200px" } };
        public static readonly Dictionary<string, object> GridStyle80WithCentre = new Dictionary<string, object> { { "width", "80px" }, { "align", "center" } };
        public static readonly Dictionary<string, object> GridStyle50WithCentre = new Dictionary<string, object> { { "width", "50px" }, { "align", "center" } };
        public static readonly Dictionary<string, object> GridStyle120WithCentre = new Dictionary<string, object> { { "width", "120px" }, { "align", "center" } };
        public static readonly Dictionary<string, object> GridStyle80 = new Dictionary<string, object> { { "width", "80px" } };
        public static readonly Dictionary<string, object> Color = new Dictionary<string, object> { { "bgcolor", "#e7f7da" } };
        public static readonly Dictionary<string, object> CenterAlign = new Dictionary<string, object> { { "align", "center" } };
        public static readonly Dictionary<string, object> GridStyle50WithRight = new Dictionary<string, object> { { "align", "right" }, { "width", "50px" } };
        public static readonly Dictionary<string, object> ActionCenterColumnStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center" }, { "width", "60px" }, { "valign", "middle" } };
        public static readonly Dictionary<string, object> GridWidthStyle = new Dictionary<string, object> { { "width", "105px" } };
        public static readonly Dictionary<string, object> UserNameStyle = new Dictionary<string, object> { { "width", "120px" } };
        public static readonly Dictionary<string, object> ActionCenterColumnDownloadStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center" }, { "width", "90px" }, { "valign", "middle" } };
        public static readonly Dictionary<string, object> StatusColumnStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center" }, { "width", "40px" }, { "valign", "middle" } };
    }

    public static class ButtonType
    {
        public const string Submit = "submit";
        public const string Button = "button";
    }
}