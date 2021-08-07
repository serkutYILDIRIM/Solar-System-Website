using System.Collections.Generic;
using System.Linq;
using SolarSystem.Data;

namespace SolarSystem.Service.BusinessService
{
    public class GenericService<Table> where Table : class, new()
    {
        private static SolarSystemContext context = new SolarSystemContext();
        public void Create(Table table)
        {
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }
        public void Update(Table table)
        {
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }
        public void Delete(Table table)
        {
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }
        public List<Table> ListAll()
        {
            return context.Set<Table>().ToList();
        }
        public Table ListWithId(int id)
        {
            return context.Set<Table>().Find(id);
        }
    }
}
