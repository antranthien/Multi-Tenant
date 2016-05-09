using MultiTenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.Controllers
{
    public class TenantController : Controller
    {
        // GET: Tenant
        public ActionResult Index()
        {
            using (var context = new MultiTenantContext())
            {
                var tenants = context.Tenants.ToList();
                return View(tenants);
            }
            
        }
    }
}