using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;

using System.Collections.Generic;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        public List<ProductModel> Get()
        {
            var data = new ProductData();

            return data.GetProducts();
        }
    }
}