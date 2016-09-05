using NetFundamentals.Model;
using NetFundamentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetFundamentals.API.Controllers
{
    [Route("customer")]
    public class CustomerController : ApiController
    {
        private IRepository<Customer> repository;

        public CustomerController()
        {
            repository = new BaseRepository<Customer>();
        }
        [HttpGet]
        [Route("customer/{id:int}")]
        public IHttpActionResult CustomeById(int id)
        {
            return Ok(repository.GetById(x => x.CustomerId == id));
        }

        [HttpGet]
        [Route("customer/")]
        public IHttpActionResult Customers()
        {
            return Ok(repository.GetList());
        }

        [HttpPut]
        public IHttpActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(repository.Add(customer));
        }

        [HttpPost]
        public IHttpActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(repository.Update(customer));
        }

        [HttpDelete]
        public IHttpActionResult Delete(Customer customer)
        {
            if (customer.CustomerId == 0) return BadRequest(ModelState);
            return Ok(repository.Delete(customer));
        }
    }
}
