using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Models.Management;
using SimpleWebApi.Services.Interfaces;

namespace SimpleWebApi.Controllers
{
    /// <summary>
    /// 员工信息接口
    /// </summary>
    [ApiController]
	[Route("api/employees")]
	public class EmployeesController : ControllerBase
	{
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
		{
            this.employeeService = employeeService;
        }

        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">页的大小</param>
        /// <returns></returns>
        [HttpGet]
		public async Task<ActionResult<PagedList<Employee>>> GetAll(int page = 1, int pageSize = 10)
		{
			return await employeeService.GetEmployees(page, pageSize);
		}
	}
}
