using Microsoft.AspNetCore.Razor.TagHelpers;
using SolarSystem.Service.Interfaces;
using System.Linq;

namespace SolarSystem.TagHelpers
{
    [HtmlTargetElement("listSatelliteName")]
    public class SatelliteName : TagHelper
    {
        private readonly IPlanetService _planetService;
        public SatelliteName (IPlanetService planetService)
        {
            _planetService = planetService;
        }
        public int PlanetId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            var satellites = _planetService.ListSatellites(PlanetId).Select(I => I.SatelliteName);
            foreach (var item in satellites)
            {
                data += item + " ";
            }
            output.Content.SetContent(data);
        }
    }
}
