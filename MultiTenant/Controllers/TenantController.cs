﻿using MultiTenant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.Controllers
{
    public class TenantController : Controller
    {
        // GET: Tenant
        public async Task<ActionResult> Index()
        {
            using (var context = new MultiTenantContext())
            {
                var tenants = await context.Tenants.ToListAsync();
                return View(tenants);
            }
            
        }
    }
}