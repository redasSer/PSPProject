using System;
using System.Collections.Generic;
using System.Linq;
using PSP.Data;
using PSP.Enums;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Services;

public class StationsService : IStationsService
{
    private readonly AppDbContext _db;
    
    private IQueryable<Station> Stations => _db.Stations;
    
    public StationsService(AppDbContext db)
    {
        _db = db;
    }
    
    public List<Station> GetAll()
    {
        return Stations.ToList();
    }

    public Station GetById(Guid id)
    {
        return _db.Stations.Find(id);
    }

    public Station Create(Station station)
    {
        Station newStation = new Station();
        
        newStation.stationId = Guid.NewGuid();
        newStation.employeeId = station.employeeId;
        newStation.locationId = station.locationId;
        newStation.seats = station.seats;
        newStation.status = station.status;
        
        _db.Stations.Add(newStation);
        _db.SaveChanges();
        
        return newStation;
    }

    public Station Update(Guid id, Station station)
    {
        Station updateStation = _db.Stations.Find(id);
        
        updateStation.employeeId = station.employeeId;
        updateStation.locationId = station.locationId;
        updateStation.seats = station.seats;
        updateStation.status = station.status;
        
        _db.Stations.Update(updateStation);
        _db.SaveChanges();
        
        return updateStation;
    }

    public Station UpdateStatus(Guid id, StationStatus status)
    {
        Station updateStation = _db.Stations.Find(id);
        
        updateStation.status = status;
        
        _db.Stations.Update(updateStation);
        _db.SaveChanges();
        
        return updateStation;
    }

    public void Delete(Guid id)
    {
        Station station = _db.Stations.Find(id);
        
        _db.Stations.Remove(station);
        _db.SaveChanges();
    }
}