using NetFundamentals.API.Models;
using NetFundamentals.Model;
using NetFundamentals.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NetFundamentals.API.Controllers
{
    //[Authorize]
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        private IRepository<Customer> repository;

        public CustomerController()
        {
            repository = new BaseRepository<Customer>();
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult CustomeById(int id)
        {
            return Ok(repository.GetById(x => x.CustomerId == id));
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
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(repository.Delete(customer));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("file")]
        public IHttpActionResult Upload()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string uploadPath = HttpContext.Current.Server.MapPath("~/uploads/");
            string picturePath = HttpContext.Current.Server.MapPath("~/pictures/");
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
            if (!Request.Content.IsMimeMultipartContent())
                return BadRequest();

            var provider = new MultipartFormDataStreamProvider(uploadPath);

            Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.FileData)
            {   
                string filename = file.Headers.ContentDisposition.FileName.Replace("\"",string.Empty);                
                File.Copy(file.LocalFileName, Path.Combine(picturePath, filename));
            }
            return Ok();
        }
    }
}
