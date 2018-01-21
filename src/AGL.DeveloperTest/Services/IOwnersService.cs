using System.Threading.Tasks;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Services
{
    public interface IOwnersService
    {
        Task<Owner[]> GetOwners();
    }
}