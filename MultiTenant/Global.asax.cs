using MultiTenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MultiTenant
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //using (var context = new MultiTenantContext())
            //{
            //    context.Speakers.Add(new Speaker
            //    {
            //        LastName = "Tran"
            //    });

            //    context.Sessions.Add(new Session
            //    {
            //        Title = "Session 1"
            //    });
            //    context.SaveChanges();
            //}

            //using(var context = new MultiTenantContext())
            //{
            //    var tenants = new List<Tenant>
            //    {
            //        new Tenant
            //        {
            //            Name = "SVCC",
            //            DomainName = "www.codecamp.com",
            //            Default = true
            //        },
            //        new Tenant
            //        {
            //            Name = "ANGU",
            //            DomainName = "angularu.com",
            //            Default = false
            //        },
            //        new Tenant
            //        {
            //            Name = "CSSC",
            //            DomainName = "codestarsubmit.com",
            //            Default = false
            //        }
            //    };
            //    context.Tenants.AddRange(tenants);
            //    context.SaveChanges();
            //}
        }
    }
}
