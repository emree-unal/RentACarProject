using System;
using System.Collections.Generic;
using ReCapProject.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.BusinessAspect.Autofac;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            this._colorService = colorService;
        }

        [HttpGet("getallcolors")]
      
        public IActionResult Get()
        {
           var result= _colorService.GetAllColors();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("getcolorbyId")]
        public IActionResult GetColorById(int id)
        {
            
            var result = _colorService.GetColorById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var color = _colorService.GetColorById(id);
            var result = _colorService.Delete(color.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(Color color)
        {

            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {

            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
