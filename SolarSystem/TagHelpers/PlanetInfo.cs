using Microsoft.AspNetCore.Razor.TagHelpers;
using SolarSystem.Service.Interfaces;
using System.Linq;

namespace SolarSystem.TagHelpers
{
    [HtmlTargetElement("PlanetInfo")]
    public class PlanetInfo:TagHelper
    {
        private readonly ISatelliteService _satelliteService;
        public PlanetInfo(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }
        public int SatelliteId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            var planets = _satelliteService.PlanetInfo(SatelliteId).Select(I => I.PlanetInfo);
            foreach (var item in planets)
            {
                data += item + " ";
            }
            output.Content.SetContent(data);
        }
    }
}
