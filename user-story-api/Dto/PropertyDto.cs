using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_story_api.Dto;

namespace user_story_api.Dto
{
public class PropertyDto
    {
    public string Title { get; set; }
    public string RealEstateType { get; set; }
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public LocationDto Location { get; set; }
}
}
