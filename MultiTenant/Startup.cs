using Owin;
using Microsoft.Owin;
using MultiTenant.Models;
using System;
using System.Data.Entity;
using System.Linq;

[assembly : OwinStartup(typeof(MultiTenant.Startup))]

namespace MultiTenant
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Tenant tenant = GetTenantBasedOnUrl(ctx.Request.Uri.Host);

                ctx.Environment.Add("Multitenant", tenant);
                await next();
            });
        }

        private Tenant GetTenantBasedOnUrl(string host)
        {
            if (string.IsNullOrEmpty(host))
            {
                throw new ApplicationException("empty urlHost");
            }

            Tenant tenant;

            using(var context = new MultiTenantContext())
            {
                DbSet<Tenant> tenants = context.Tenants;
                tenant = tenants.FirstOrDefault(t => t.DomainName.ToLower().Equals(host)) ??
                    tenants.FirstOrDefault(t => t.Default);

                if(tenant == null)
                {
                    throw new ApplicationException("tenant not found");
                }

                return tenant;
            }
        }
    }
}