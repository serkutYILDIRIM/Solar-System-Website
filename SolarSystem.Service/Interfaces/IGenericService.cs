using System.Collections.Generic;

namespace SolarSystem.Service.Interfaces
{
    public interface IGenericService<Table> where  Table :class, new()
    {
        void Create(Table table);
        void Update(Table table);
        void Delete(Table table);
        List<Table> ListAll();
        Table ListWithId(int id);
    }
}
