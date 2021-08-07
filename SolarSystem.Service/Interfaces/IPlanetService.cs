using System.Collections.Generic;
using SolarSystem.Data.Models;

namespace SolarSystem.Service.Interfaces
{
    public interface IPlanetService : IGenericService<Planet>
    {
        public List<Satellite> ListSatellites(int planetId);
        void AddSatellite(PlanetSatellite planetSatellite);
        void DeleteSatellite(PlanetSatellite planetSatellite);

    }
}
