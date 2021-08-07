using Microsoft.AspNetCore.Razor.TagHelpers;
using SolarSystem.Service.Interfaces;
using System.Linq;

namespace SolarSystem.TagHelpers
{
    [HtmlTargetElement("listPlanetName")]
    public class PlanetName : TagHelper
    {
        private readonly ISatelliteService _satelliteService;
        public PlanetName(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }
        public int SatelliteId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            var planets = _satelliteService.ListPlanets(SatelliteId).Select(I => I.PlanetName);
            foreach (var item in planets)
            {
                data += item + " ";
            }
            output.Content.SetContent(data);
        }
    }
}
