using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using user_story_api.Data;
using user_story_api.Dto;

namespace user_story_api.Services.PropertyService
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public PropertyRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public List<PropertyDto> GetProperties(PropertyQueryStringDto propertyQueryStringDto)
        {
            var rootPath = _hostingEnvironment.ContentRootPath;
            var fullPath = Path.Combine(rootPath, "Data/PropertyData.json");
            var jsonData = System.IO.File.ReadAllText(fullPath);

            if (string.IsNullOrWhiteSpace(jsonData))
                return null;

            List<PropertyDto> properties = JsonConvert.DeserializeObject<List<PropertyDto>>(jsonData);

            if (properties == null || properties.Count == 0)
                return null;

            List<PropertyDto> filteredData = properties.Where(s =>
                            s.RealEstateType == propertyQueryStringDto.PropertyType &&
                            s.Location.Latitude > propertyQueryStringDto.MinLat &&
                            s.Location.Latitude < propertyQueryStringDto.MaxLat &&
                            s.Location.Longitude > propertyQueryStringDto.MinLng &&
                            s.Location.Longitude < propertyQueryStringDto.MaxLng).ToList();

            return filteredData;
        }
    }
}
