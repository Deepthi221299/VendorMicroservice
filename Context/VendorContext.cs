using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Models;

namespace VendorMicroService.Context
{
    public class VendorContext:DbContext
    {
        public VendorContext(DbContextOptions<VendorContext> option) : base(option)
        {

        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorStock> VendorStocks { get; set; }
    }
}
