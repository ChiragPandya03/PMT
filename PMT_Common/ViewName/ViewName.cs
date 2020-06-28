using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMT_Common.ViewName
{
    public static class ViewName
    {
        public const string Login = "~/Views/Login/Login.cshtml";
        public const string IndexPage = "~/Views/General/Index.cshtml";
        public const string Dashboard = "~/Views/Dashboard/Dashboard.cshtml";
        public const string ErrorIndex = "~/Views/General/Error.cshtml";
        public const string SessionTimeOut = "~/Views/General/SessionTimeOut.cshtml";
        public const string AccessDenied = "~/Views/General/AccessDenied.cshtml";

        public const string Header = "~/Views/PartialView/Header.cshtml";

        public const string UserList = "~/Views/Admin/User/UserList.cshtml";
        public const string UserManagement = "~/Views/Admin/User/UserManagement.cshtml";
        public const string UserAccessRole = "~/Views/Admin/User/UserAccessRole.cshtml";
        public const string UserProfile = "~/Views/Admin/User/UserProfile.cshtml";

        public const string AccessRoleList = "~/Views/Admin/AccessRole/AccessRoleList.cshtml";
        public const string AccessRoleManagement = "~/Views/Admin/AccessRole/AccessRoleManagement.cshtml";
        public const string RoleUsers = "~/Views/Admin/AccessRole/RoleUsers.cshtml";

        public const string Popup = "~/Views/PartialView/PopupView.cshtml";
    }
}
