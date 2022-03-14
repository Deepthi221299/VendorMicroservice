using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroService.Models;
using VendorMicroService.Repository;

namespace VendorMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        IVendorDetail<Vendor> _vendor;
        // private readonly ILogger<VendorController> _logger;
        //  static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(VendorController));
        public VendorController(IVendorDetail<Vendor> vendor)
        {
            _vendor = vendor;
            //  _logger = logger;
        }

        // GET: api/<VendorController>
        [HttpGet]
        public IEnumerable<Vendor> Get()
        {
            return _vendor.GetAll();
        }

        // GET api/<VendorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //log4net.Info("Getting Info");
            return Ok(_vendor.GetVendor(id));
        }

        // POST api/<VendorController>
        [HttpPost]
        public void Post([FromBody] VendorStock vs)
        {
            _vendor.PostStock(vs);
        }
    }
}
