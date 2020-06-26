using Capstone_FotoMe.Models;
using System.Threading.Tasks;

namespace Capstone_FotoMe.Services
{
    public interface IAPIService
    {
        Task<GeoCode> Geocoding(string address);
    }
}