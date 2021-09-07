using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediorTest.LocationDataSetHandler
{
    public class LocationSerializer
    {
        public List<LocationModel> SerializeLocations()
        {
            List<LocationModel> locations = new List<LocationModel>();
            using (StreamReader reader = new StreamReader(@"C:\Users\lorik\Desktop\Lori\Roamler\MediorTest\MediorTest\DataSet\Locations.json"))
            {
                string jsonObj = reader.ReadToEnd();
                locations = JsonConvert.DeserializeObject<List<LocationModel>>(jsonObj);
            }

            var res = locations.Where(_ => string.IsNullOrEmpty(_.Name) || string.IsNullOrEmpty(_.Address) ||
                                 string.IsNullOrEmpty(_.Latitude) || string.IsNullOrEmpty(_.Longitude)).ToList();


            res.ForEach(fault => { locations.Remove(fault); });

            return locations;
        }
    }
}
