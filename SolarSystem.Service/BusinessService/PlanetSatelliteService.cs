using System;
using System.Linq;
using System.Linq.Expressions;
using SolarSystem.Data;
using SolarSystem.Data.Models;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Service.BusinessService
{
    public class PlanetSatelliteService : GenericService<PlanetSatellite>, IPlanetSatelliteService
    {
        public PlanetSatellite ListWithFilter(Expression<Func<PlanetSatellite, bool>> filter)
        {
            using var context = new SolarSystemContext();

            return context.PlanetSatellites.FirstOrDefault(filter);
        }
    }
}
