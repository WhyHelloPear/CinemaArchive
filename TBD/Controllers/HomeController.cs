using Geocoding;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TBD.Models;

namespace TBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IGeocoder _geoCoder { get; }

        public HomeController(IGeocoder geoCoder)
        {
            _geoCoder = geoCoder;
        }

        [HttpGet("DoThis")]
        public async Task<UserData> DoThis(double lat, double longitude)
        {
            var address = (await _geoCoder.ReverseGeocodeAsync(lat, longitude)).FirstOrDefault();

            return new UserData(address.FormattedAddress);
        }
    }
}
