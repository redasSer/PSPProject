using PSP.Models;
using System.Collections.Generic;
using System;

namespace PSP.Interfaces
{
    public interface ILocationService
    {
        List<Location> GetAll();
        Location GetById(Guid id);
        Location Create(Location location);
        Location Update(Guid id, Location location);
        void Delete(Guid id);
    }
}
