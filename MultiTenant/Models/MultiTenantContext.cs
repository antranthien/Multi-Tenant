﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MultiTenant.Models
{
    public class MultiTenantContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
    }
}