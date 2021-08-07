using System.Collections.Generic;
using System.Linq;
using SolarSystem.Data;
using SolarSystem.Data.Models;
using SolarSystem.Service.Interfaces;

namespace SolarSystem.Service.BusinessService
{
    public class SatelliteService : GenericService<Satellite>, ISatelliteService
    {
        public List <Planet> ListPlanets(int satelliteId)
        {
            using var context = new SolarSystemContext();

            return context.Satellites.Join(context.PlanetSatellites, satellite => satellite.SatelliteId, planetSatellite => planetSatellite.SatelliteId, (s, ps) => new
            {
                satellite = s,
                planetSatellite = ps
            }).Join(context.Planets, two => two.planetSatellite.PlanetId, planet => planet.PlanetId, (ps, p) => new
            {
                satellite = ps.satellite,
                planet = p,
                planetSatellite = ps.planetSatellite
            }).Where(I => I.satellite.SatelliteId == satelliteId).Select(I => new Planet
            {
                PlanetName = I.planet.PlanetName,
                PlanetId = I.planet.PlanetId
            }).ToList();
        }
        public List<Planet> PlanetInfo(int satelliteId)
        {
            using var context = new SolarSystemContext();

            return context.Satellites.Join(context.PlanetSatellites, satellite => satellite.SatelliteId, planetSatellite => planetSatellite.SatelliteId, (s, ps) => new
            {
                satellite = s,
                planetSatellite = ps
            }).Join(context.Planets, two => two.planetSatellite.PlanetId, planet => planet.PlanetId, (ps, p) => new
            {
                satellite = ps.satellite,
                planet = p,
                planetSatellite = ps.planetSatellite
            }).Where(I => I.satellite.SatelliteId == satelliteId).Select(I => new Planet
            {
                PlanetInfo = I.planet.PlanetInfo,
                PlanetId = I.planet.PlanetId
            }).ToList();
        }
        public List<Planet> PlanetImg(int satelliteId)
        {
            using var context = new SolarSystemContext();

            return context.Satellites.Join(context.PlanetSatellites, satellite => satellite.SatelliteId, planetSatellite => planetSatellite.SatelliteId, (s, ps) => new
            {
                satellite = s,
                planetSatellite = ps
            }).Join(context.Planets, two => two.planetSatellite.PlanetId, planet => planet.PlanetId, (ps, p) => new
            {
                satellite = ps.satellite,
                planet = p,
                planetSatellite = ps.planetSatellite
            }).Where(I => I.satellite.SatelliteId == satelliteId).Select(I => new Planet
            {
                Picture = I.planet.Picture,
                PlanetId = I.planet.PlanetId
            }).ToList();
        }

        public List<Satellite> ListWithPlanetId(int planetId)
        {
            using var context = new SolarSystemContext();

            return context.Satellites.Join(context.PlanetSatellites, s => s.SatelliteId, ps => ps.SatelliteId, (satellite, planetSatellite) => new
            {
                Satellite = satellite,
                PlanetSatellite = planetSatellite
            }).Where(I => I.PlanetSatellite.PlanetId == planetId).Select(I => new Satellite
            {
                SatelliteId = I.Satellite.SatelliteId,
                SatelliteName = I.Satellite.SatelliteName,
                SatelliteInfo = I.Satellite.SatelliteInfo,
                Picture = I.Satellite.Picture
            }).ToList();
        }
    }
}
