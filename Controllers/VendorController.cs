using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    /*[Produces("application/json")]
    [Authorize(Roles = "User")]*/
    public class VendorController : ControllerBase
    {
        IVendorDetail<Vendor> _vendor;
        private readonly ILogger<VendorController> logger;
        private readonly log4net.ILog _log4net;
         
        public VendorController(IVendorDetail<Vendor> vendor, ILogger<VendorController> _logger)
        {
            _vendor = vendor;
            logger = _logger;
             _log4net= log4net.LogManager.GetLogger(typeof(VendorController));
        }

        // GET: api/<VendorController>
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IEnumerable<Vendor> Get()
        {
            return _vendor.GetAll();
        }

        // GET api/<VendorController>/5
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public IActionResult GetVendorById(int id)
        {
            _log4net.Info("Getting Info");
            return Ok(_vendor.GetVendor(id));
        }

        [HttpGet("VendorId")]
        public IActionResult GetVendorStock(int Id)
        {
            return Ok(_vendor.GetVendorStockById(Id));
        }
        
    }
}
