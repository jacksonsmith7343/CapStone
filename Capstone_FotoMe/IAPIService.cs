using Capstone_FotoMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_FotoMe
{
    interface IAPIService
    {
        public interface IAPIService
        {

            Task<GeoCode> GoogleGeocoding(string address);


        }

        Task<GeoCode> GoogleGeocoding(string geoAddress);
    }
}
