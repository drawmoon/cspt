using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Models.Management;
using SimpleWebApi.Services.Interfaces;

namespace SimpleWebApi.Controllers
{
	[ApiController]
	[Route("api/employees")]
	public class EmployeesController : ControllerBase
	{
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
		{
            this.employeeService = employeeService;
        }

		[HttpGet]
		public async Task<ActionResult<PagedList<Employee>>> GetAll(int page = 1, int pageSize = 10)
		{
			return await employeeService.GetEmployees(page, pageSize);
		}
	}
}
