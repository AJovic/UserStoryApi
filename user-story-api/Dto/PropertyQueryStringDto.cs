using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_story_api.Data
{
    public class PropertyQueryStringDto
    {
        public string PropertyType { get; set; }
        public double MinLat { get; set; }
        public double MaxLat { get; set; }
        public double MinLng { get; set; }
        public double MaxLng { get; set; }
    }
}
