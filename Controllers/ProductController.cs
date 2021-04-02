using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class ProductController : ApiController
    {
        static List<Product> _productList = null;
        void Initialize()
        {
            _productList = new List<Product>()
           {
               new Product() { ProductId=1, Name="prateek" , QtyInStock="50", Description="Ordered", Supplier="Amit"},

               new Product() { ProductId=2, Name="yash" , QtyInStock="50", Description="Received", Supplier="Rahul"},
           };

        }
        public ProductController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }

        // GET: api/Products
        public List<Product> Get()
        {
            return _productList;
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            Product product = _productList.FirstOrDefault(x => x.ProductId == id);

            return product;
        }

        // POST: api/Products
        public void Post(Product product)
        {
            if (product != null)
            {
                _productList.Add(product);
            }

        }

        // PUT: api/Products/5
        public void Put(int id, Product objProduct)
        {
            Product product = _productList.Where(x => x.ProductId == id).FirstOrDefault();

            if (product != null)
            {
                foreach (Product temp in _productList)
                {
                    if (temp.ProductId == id)
                    {
                        temp.Name = objProduct.Name;
                        temp.QtyInStock = objProduct.QtyInStock;
                        temp.Description = objProduct.Description;
                        temp.Supplier = objProduct.Supplier;
                    }
                }

            }
        }

        // DELETE: api/Products/5
        public HttpResponseMessage Delete(int id)
        {
            Product product = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "product Not found");

            }
            else
            {
                if (product != null)
                {
                    _productList.Remove(product);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }

        }

    }
}

