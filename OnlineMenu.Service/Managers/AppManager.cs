using OnlineMenu.Model;
using OnlineMenu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineMenu.Service.Managers
{
    public class AppManager
    {
        public static void SetInitialSessions()
        {
            try
            {
                var db = new OnlineMenuEntities();
                var LogosFilePath = db.Settings.First().LogosFilePath;
                HttpContext.Current.Session["LogosFilePath"] = LogosFilePath;
            }
            catch
            {
            }
        }

        public static string GetLogosFilePath()
        {
            return (String)System.Web.HttpContext.Current.Session["LogosFilePath"];
        }

        public static VMUser SetCurrentUserInfo(string domainName)
        {
            if (string.IsNullOrEmpty(domainName))
            {
                domainName = HttpContext.Current.User.Identity.Name;
            }

            OnlineMenuEntities db = new OnlineMenuEntities();
            var vmUser = new VMUser();

            //try
            //{
            //    var userGroups = db.vwFrameworkUserGroups.Where(u => u.DomainName == domainName);
            //    vmUser = Mapper.Map<VMUser>(userGroups.FirstOrDefault());

            //    if (vmUser != null)
            //    {
            //        var userTracking = db.vwFrameworkUserGroups.FirstOrDefault(u => u.DomainName == HttpContext.Current.User.Identity.Name);
            //        vmUser.TrackingUser = Mapper.Map<VMUser>(userTracking);

            //        var aDGroupsList = userGroups.Select(t => t.Department).ToList();
            //        vmUser.DepartmentList = aDGroupsList;
            //        vmUser.UserTypeId = GetUserTypeId(aDGroupsList);
            //        vmUser.DepartmentsId = GetDepartmentId(aDGroupsList);
            //    }
            //    else
            //    {
            //        vmUser = new VMUser()
            //        {
            //            DomainName = domainName,
            //            UserTypeId = UserType.Reader
            //        };
            //    }
            //}
            //catch
            //{
            //    return vmUser;
            //}

            HttpContext.Current.Session.Add("_SessionUser", vmUser);

            return vmUser;
        }
    }
}