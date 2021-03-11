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
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet("getallcustomers")]
        public IActionResult Get()
        {
          var result= _customerService.GetAllCustomers();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getcustomerbyId")]
        public IActionResult GetCustomerById(int id)
        {
            var result= _customerService.GetCustomerById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomerById(id);
          var result=  _customerService.Delete(customer.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(Customer customer)
        {

           var result= _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {

            var result=_customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
