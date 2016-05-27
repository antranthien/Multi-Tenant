﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant.Models
{
    public class Tenant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DomainName { get; set; }

        //only 1  tenant is allowed to be true
        public bool Default { get; set; }

    }
}