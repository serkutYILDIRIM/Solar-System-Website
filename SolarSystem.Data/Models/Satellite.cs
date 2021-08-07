using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SolarSystem.Data.Models
{
    public class Satellite
    {
        public int SatelliteId { get; set; }
        [MaxLength(100)]
        public string SatelliteName { get; set; }
        public string SatelliteInfo { get; set; }
        [MaxLength(250)]
        public string Picture { get; set; }
        public List<PlanetSatellite> PlanetSatellites { get; set; }
    }
}
