﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant.Models
{
    public class Session
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public Tenant Tenant { get; set; }

        public List<Speaker> Speakers { get; set; }

    }
}