using System.Collections.Generic;
using System.Linq;
using SolarSystem.Data;
using SolarSystem.Data.Models;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Service.BusinessService
{
    public class PlanetService : GenericService<Planet>, IPlanetService
    {
        private readonly IPlanetSatelliteService _planetSatelliteService;
        public PlanetService(IPlanetSatelliteService planetSatelliteService)
        {
            _planetSatelliteService = planetSatelliteService;
        }
        public List<Satellite> ListSatellites(int planetId)
        {
            using var context = new SolarSystemContext();

            return context.Planets.Join(context.PlanetSatellites, satellite => satellite.PlanetId, planetSatellite => planetSatellite.PlanetId, (p, ps) => new 
            {
                planet = p,
                planetSatellite = ps
            }).Join(context.Satellites, two => two.planetSatellite.SatelliteId, planet => planet.SatelliteId, (ps, s) => new 
            {
                planet = ps.planet,
                satellite = s,
                planetSatellite = ps.planetSatellite
            }).Where(I => I.planet.PlanetId == planetId).Select(I => new Satellite 
            {
                SatelliteName = I.satellite.SatelliteName,
                SatelliteId = I.satellite.SatelliteId
            }).ToList();
        }
        public void DeleteSatellite(PlanetSatellite planetSatellite)
        {
            var controlRecord = _planetSatelliteService.ListWithFilter(I => I.SatelliteId == planetSatellite.SatelliteId && I.PlanetId == planetSatellite.PlanetId);

            if (controlRecord != null)
            {
                _planetSatelliteService.Delete(controlRecord);
            }
        }
        public void AddSatellite(PlanetSatellite planetSatellite)
        {
            var controlRecord = _planetSatelliteService.ListWithFilter(I => I.SatelliteId == planetSatellite.SatelliteId && I.PlanetId == planetSatellite.PlanetId);

            if (controlRecord == null)
            {
                _planetSatelliteService.Create(planetSatellite);
            }
        }
    }
}
