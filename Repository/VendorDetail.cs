using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Context;
using VendorMicroService.Models;

namespace VendorMicroService.Repository
{
    public class VendorDetail:IVendorDetail<Vendor>
    {
        public VendorContext _context;
        public VendorDetail(VendorContext context)
        {
            _context = context;
        }
        public IEnumerable<Vendor> GetAll()
        {
            return _context.Vendors.ToList();
        }
        
        public List<VendorStock>  GetVendorStockById(int id)
        {
            return _context.VendorStocks.Include(v => v.Vendor).Where(x => x.ProductId == id).ToList();
        }
        public IEnumerable<Vendor> GetVendor(int id)
        {
            try
            {

                IEnumerable<VendorStock> vs = _context.VendorStocks.Include(v => v.Vendor).Where(v => v.ProductId == id && v.HandInStocks > 0);
                return vs.Select(v => v.Vendor);
            }
            catch (Exception)
            {
                return null;
            }

        }
        
    }
}
