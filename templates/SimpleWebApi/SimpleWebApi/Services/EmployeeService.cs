using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Models.Management;
using SimpleWebApi.Repositories.Interfaces;
using SimpleWebApi.Services.Interfaces;

namespace SimpleWebApi.Services
{
	public class EmployeeService : IEmployeeService
	{
        private readonly IEmployeeRepository employeRepository;

        public EmployeeService(IEmployeeRepository employeRepository)
		{
            this.employeRepository = employeRepository;
        }

        public async Task<PagedList<Employee>> GetEmployees(int page = 1, int pageSize = 10)
        {
            return await employeRepository.Entities.ToPagedListAsync(page, pageSize);
        }
    }
}
