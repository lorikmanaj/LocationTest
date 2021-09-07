using MediorTest.LocationDataSetHandler;
using MediorTest.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediorTest.Implentation
{
    public class LocationService : ILocationService
    {
        readonly string path = "";
        public LocationService()
        {
            path = @"C:\Users\lorik\Desktop\Lori\Roamler\MediorTest\MediorTest\DataSet\Locations.json";
        }
        public LocationModel Delete(string name)
        {
            List<LocationModel> locations = new List<LocationModel>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string jsonObj = reader.ReadToEnd();
                    locations = JsonConvert.DeserializeObject<List<LocationModel>>(jsonObj);
                    reader.Dispose();
                }
                var locationToRemove = locations.Where(_ => _.Name == name).FirstOrDefault();
                locations.Remove(locationToRemove);
                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(locations));
                return locationToRemove;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public LocationModel Insert(LocationModel model)
        {
            List<LocationModel> locations = new List<LocationModel>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string jsonObj = reader.ReadToEnd();

                    locations = JsonConvert.DeserializeObject<List<LocationModel>>(jsonObj);
                    reader.Dispose();
                }
                locations.Add(model);
                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(locations));
                return model;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<LocationModel> Read()
        {
            List<LocationModel> locations = new List<LocationModel>();
            using (StreamReader reader = new StreamReader(path))
            {
                string jsonObj = reader.ReadToEnd();
                locations = JsonConvert.DeserializeObject<List<LocationModel>>(jsonObj);
                reader.Dispose();
            }

            var res = locations.Where(_ => string.IsNullOrEmpty(_.Name) || string.IsNullOrEmpty(_.Address) ||
                                 string.IsNullOrEmpty(_.Latitude) || string.IsNullOrEmpty(_.Longitude)).ToList();


            res.ForEach(fault => { locations.Remove(fault); });

            return locations;
        }

        public LocationModel Update(LocationModel model)
        {
            List<LocationModel> locations = new List<LocationModel>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string jsonObj = reader.ReadToEnd();
                    locations = JsonConvert.DeserializeObject<List<LocationModel>>(jsonObj);
                    reader.Dispose();
                }
                var l = locations.Where(_ => _.Name == model.Name).FirstOrDefault();
                locations.Remove(l);
                locations.Add(model);
                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(locations));
                return model;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
