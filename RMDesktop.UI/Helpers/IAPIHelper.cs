using RMDesktop.UI.Models;
using System.Threading.Tasks;

namespace RMDesktop.UI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}