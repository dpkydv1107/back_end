using Domainlayer.Data;
using Domainlayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicelayer;
using System.Globalization;

namespace MobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentYearController : ControllerBase
    {
        private readonly IService<CurrentYear> _customService;
        private readonly ApplicationDbContext _applicationDbContext;
        public CurrentYearController(IService<CurrentYear> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }
       
       
        [HttpGet(nameof(GetAllCurrentYear))]
        public IActionResult GetAllCurrentYear()
        {
            var obj = _customService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpGet(nameof(GetCurrentYearByEmployeeName))]
        public IActionResult GetCurrentYearByEmployeeName(string employeeName)
        {
            var currentYearData = _customService.GetAll()
                .Where(data => data.Employee_name == employeeName)
                .ToList();

            if (currentYearData.Any())
            {
                return Ok(currentYearData);
            }
            else
            {
                return NotFound($"No data found for employee with name: {employeeName}");
            }
        }
        [HttpGet(nameof(GetCurrentYearByMonth))]
        public IActionResult GetCurrentYearByMonth(string month)
        {
            // Parse the string month to DateTime format
            if (DateTime.TryParseExact(month, "MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedMonth))
            {
                var currentYearData = _customService.GetAll()
                    .Where(data => data.Date.Month == parsedMonth.Month )
                    .ToList();

                if (currentYearData.Any())
                {
                    return Ok(currentYearData);
                }
                else
                {
                    return NotFound($"No data found for the specified month: {month}");
                }
            }
            else
            {
                return BadRequest("Invalid month format. Use YYYY-MM format.");
            }
        }

        [HttpPost(nameof(CreateCurrentYear))]
        public IActionResult CreateCurrentYear(CurrentYear currentyear)
        {
            if (currentyear != null)
            {
                _customService.Insert(currentyear);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        
       
    }
}

