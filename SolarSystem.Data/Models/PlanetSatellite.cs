namespace SolarSystem.Data.Models
{
    public class PlanetSatellite
    {
        public int Id { get; set; }
        public int SatelliteId { get; set; }
        public Satellite Satellite { get; set; }
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }
    }
}
