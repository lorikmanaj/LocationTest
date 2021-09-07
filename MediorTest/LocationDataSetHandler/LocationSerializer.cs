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
        public LocationSerializer()
        {

        }

        public List<LocationModel> SerializeLocations()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\lorik\Desktop\Lori\Roamler\MediorTest\MediorTest\DataSet\Locations.json"))
            {
                string jsonObj = reader.ReadToEnd();
                var locations = JsonConvert.DeserializeObject<List<LocationModel>>(jsonObj);
            }
                
            return null;
        }
    }
}
