using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleWebApi.Models.Management;

namespace SimpleWebApi.Services.Interfaces
{
	public interface IEmployeeService
	{
		Task<PagedList<Employee>> GetEmployees(int page = 1, int pageSize = 10);
	}
}
