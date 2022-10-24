using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_story_api.Data;
using user_story_api.Dto;

namespace user_story_api.Services.PropertyService
{
    public interface IPropertyRepository
    {
        List<PropertyDto> GetProperties(PropertyQueryStringDto propertyQueryStringDto);
    }
}
