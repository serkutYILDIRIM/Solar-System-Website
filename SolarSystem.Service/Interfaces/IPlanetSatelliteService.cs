using System;
using System.Linq.Expressions;
using SolarSystem.Data.Models;

namespace SolarSystem.Service.Interfaces
{
    public interface IPlanetSatelliteService : IGenericService<PlanetSatellite>
    {
        public PlanetSatellite ListWithFilter(Expression<Func<PlanetSatellite, bool>> filter);
    }
}
