using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VolleyBizWebApi.Applications.Interfaces;
using VolleyBizWebApi.Applications.Models;

namespace VolleyBizWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeRepository employeeRepository) : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        [HttpGet("GetAllEmp")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var result = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(result);
        }

        [HttpGet("GetEmp")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromQuery] int id)
        {
            var result = await _employeeRepository.GetEmployeeByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("AddEmp")]
        public async Task<IActionResult> AddEmp([FromBody] EmployeeViewModel employeeView)
        {
            var result = await _employeeRepository.AddEmployeeAsyn(employeeView);
            return Ok(result);
        }

        [HttpPut("EditEmp")]
        public async Task<IActionResult> EditEmp(EmployeeViewModel employeeView)
        {
            var result = await _employeeRepository.EditEmployeeAsync(employeeView);
            return Ok(result);
        }

        [HttpDelete("DeleteEmp")]
        public async Task<IActionResult> DeleteEmp([FromQuery] int id)
        {
            var result = await _employeeRepository.DeleteEmployeeAsync(id);
            return Ok(result);
        }
    }
}
