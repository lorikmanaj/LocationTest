using MediorTest.Helper;
using MediorTest.LocationDataSetHandler;
using MediorTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediorTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet]
        public IActionResult Get()
        {
           return Ok(new ReturnObj() { Status = 200, Message = "LST_LOCATION_FOUND", Data = _locationService.Read(), Success = true });
        }

        [HttpPost]
        public IActionResult Add(LocationModel model)
        {
            return Ok(new ReturnObj() { Status = 200, Message = "LOCATION_ADD", Data = _locationService.Insert(model), Success = true });
        }
        [HttpDelete("{name}")]
        public IActionResult Remove(string name)
        {
            return Ok(new ReturnObj() { Status = 200, Message = "LOCATION_DELETED", Data = _locationService.Delete(name), Success = true });
        }

        [HttpPut]
        public IActionResult Update(LocationModel model)
        {
            return Ok(new ReturnObj() { Status = 200, Message = "LOCATION_UPDATED", Data = _locationService.Update(model), Success = true });
        }
    }
}
