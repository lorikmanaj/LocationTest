using MediorTest.LocationDataSetHandler;
using MediorTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediorTest.Implentation
{
    public class LocationService : ILocationService
    {
        public LocationModel Delete()
        {
            throw new NotImplementedException();
        }

        public LocationModel Insert()
        {
            throw new NotImplementedException();
        }

        public List<LocationModel> Read()
        {
            return new LocationSerializer().SerializeLocations();
        }

        public LocationModel Update()
        {
            throw new NotImplementedException();
        }
    }
}
