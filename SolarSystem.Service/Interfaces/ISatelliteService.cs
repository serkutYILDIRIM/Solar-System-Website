using System.Collections.Generic;
using SolarSystem.Data.Models;

namespace SolarSystem.Service.Interfaces
{
    public interface ISatelliteService : IGenericService<Satellite>
    {
        public List<Planet> ListPlanets(int satelliteId);
        public List<Planet> PlanetInfo(int satelliteId);
        public List<Planet> PlanetImg(int satelliteId);
        List<Satellite> ListWithPlanetId(int planetId);
    }
}
