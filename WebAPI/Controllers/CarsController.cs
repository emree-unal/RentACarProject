using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProject.Business.Abstract;
using ReCapProject.Core.Aspects.Autofac.Performance;
using ReCapProject.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet("getallcars")]
      
        public IActionResult Get()
        {
           var result= carService.GetAllCars();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getcarbyId")]
        public IActionResult GetCarById(int id)
        {
           var result= carService.GetCarById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var car = carService.GetCarById(id);
            
            var result = carService.Delete(car.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
           
            var result=carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
