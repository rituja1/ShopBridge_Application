using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ShopBridge_Application;

namespace ShopBridge_Application.Controllers
{
    public class ProductController : ApiController
    {
        private DbEntity db = new DbEntity();

        // GET: api/Product
        public IQueryable<Product_info> GetProduct_info()
        {
            return db.Product_info;
        }

        // GET: api/Product/5
        [ResponseType(typeof(Product_info))]
        public IHttpActionResult GetProduct_info(int id)
        {
            Product_info product_info = db.Product_info.Find(id);
            if (product_info == null)
            {
                return NotFound();
            }

            return Ok(product_info);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct_info(int id, Product_info product_info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product_info.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product_info).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_infoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Product
        [ResponseType(typeof(Product_info))]
        public IHttpActionResult PostProduct_info(Product_info product_info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product_info.Add(product_info);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product_info.ProductID }, product_info);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(Product_info))]
        public IHttpActionResult DeleteProduct_info(int id)
        {
            Product_info product_info = db.Product_info.Find(id);
            if (product_info == null)
            {
                return NotFound();
            }

            db.Product_info.Remove(product_info);
            db.SaveChanges();

            return Ok(product_info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Product_infoExists(int id)
        {
            return db.Product_info.Count(e => e.ProductID == id) > 0;
        }
    }
}