using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PSP.Enums;
using PSP.Interfaces;
using PSP.Models;

namespace PSP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StationsController
{
    private readonly IStationsService _stationService;
    
    public StationsController(IStationsService stationService)
    {
        _stationService = stationService;
    }

    [HttpGet]
    public List<Station> GetAll()
    {
        return _stationService.GetAll();
    }
    
    [HttpGet("{id:guid}")]
    public Station GetById(Guid id)
    {
        return _stationService.GetById(id);
    }
    
    [HttpPost]
    public Station Create(Station station)
    {
        return _stationService.Create(station);
    }
    
    [HttpPut("{id:guid}")]
    public Station Update(Guid id, Station station)
    {
        return _stationService.Update(id, station);
    }
    
    [HttpPut("{id:guid}/status/{status}")]
    public Station UpdateStatus(Guid id, StationStatus status)
    {
        return _stationService.UpdateStatus(id, status);
    }
    
    [HttpDelete("{id:guid}")]
    public void Delete(Guid id)
    {
        _stationService.Delete(id);
    }
}