using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;

using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            var sql = new SqlDataAccess();

            var p = new { };

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", p, "RMData");

            return output;
        }
    }
}