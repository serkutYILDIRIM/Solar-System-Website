using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SolarSystem.Data.Models
{
    public class Planet
    {
        public int PlanetId { get; set; }
        [MaxLength(100)]
        public string PlanetName { get; set; }
        [MaxLength(100)]
        public string DistanceToSun { get; set; }
        [MaxLength(100)]
        public string OneWayLightTimeToSun { get; set; }
        [MaxLength(100)]
        public string LengthOfYear { get; set; }
        [MaxLength(100)]
        public string PlanetType { get; set; }
        [MaxLength(100)]
        public string PlanetInfo { get; set; }
        [MaxLength(250)]
        public string Picture { get; set; }
        public List<PlanetSatellite> PlanetSatellites { get; set; }
    }
}