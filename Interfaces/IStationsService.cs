using System;
using System.Collections.Generic;
using PSP.Enums;
using PSP.Models;

namespace PSP.Interfaces;

public interface IStationsService
{
    List<Station> GetAll();
    Station GetById(Guid id);
    Station Create(Station station);
    Station Update(Guid id, Station station);
    Station UpdateStatus(Guid id, StationStatus status);
    void Delete(Guid id);
}