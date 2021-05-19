using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCapProject.Business.Abstract;
using ReCapProject.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        [HttpGet("getallbrands")]
        public IActionResult Get()
        {
            var result= _brandService.GetAllBrands();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbrandbyId")]
        public IActionResult GetBrandById(int id)
        {
            var result= _brandService.GetBrandById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbrandbybrandname")]
        public IActionResult GetBrandByBrandName(string brandName)
        {
            var result = _brandService.GetBrandByBrandName(brandName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var brand = _brandService.GetBrandById(id);
           var result = _brandService.Delete(brand.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
       
        public IActionResult Update(Brand brand)
        {

           var result= _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {

           var result= _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
