using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_story_api.Data;
using user_story_api.Services.PropertyService;

namespace user_story_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoriesController : ControllerBase
    {

        private readonly IPropertyRepository _propertyRepository;

        public UserStoriesController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpGet("properties")]
        public IActionResult GetProperties([FromQuery] PropertyQueryStringDto propertyQueryStringDto) 
        {
            try
            {
                var properties = _propertyRepository.GetProperties(propertyQueryStringDto);

                return Ok(properties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }

        }
    }
}
