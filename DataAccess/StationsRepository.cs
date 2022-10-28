using AutoMapper;
using DataAccess.Interfaces;
using DataProvider;
using Models;
using Models.Dto;
using Models.WorkerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataService
{
    public class StationsRepository : IStationsRepository
    {
        public IDataStorage storage { get; set; }

        public StationsRepository(IDataStorage storage)
        {
            this.storage = storage;
        }

        public List<OfficeStation> GetAllStations()
        {
            return this.storage.GetStations();
        }

        public OfficeStation AddStation(string signature)
        {
            var station = new OfficeStation(Guid.NewGuid(), signature, Guid.Empty);
            this.storage.GetStations().Add(station);
            return station;
        }
    }
}
