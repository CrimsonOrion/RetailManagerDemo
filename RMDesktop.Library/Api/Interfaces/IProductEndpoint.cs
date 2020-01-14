using RMDesktop.Library.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDesktop.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}