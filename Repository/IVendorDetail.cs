using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Models;

namespace VendorMicroService.Repository
{
    public interface IVendorDetail<Vendor>
    {
        public IEnumerable<Vendor> GetAll();
        public IEnumerable<Vendor> GetVendor(int Id);
        public List<VendorStock> GetVendorStockById(int id);


    }
}
