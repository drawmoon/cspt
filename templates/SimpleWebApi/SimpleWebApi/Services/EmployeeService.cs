using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NInfra.LinqExtensions.Extensions;
using SimpleWebApi.Dtos;
using SimpleWebApi.Models.Management;
using SimpleWebApi.Repositories.Interfaces;
using SimpleWebApi.Services.Interfaces;

namespace SimpleWebApi.Services
{
	public class EmployeeService : IEmployeeService
	{
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
		{
            this.employeeRepository = employeeRepository;
        }

        public async Task<PagedList<EmployeeDTO>> GetEmployees(int page = 1, int pageSize = 10)
        {
            var employees = await employeeRepository.Entities.ToPagedListAsync(page, pageSize);
            return employees.Adapt<PagedList<EmployeeDTO>>();
        }
    }
}
