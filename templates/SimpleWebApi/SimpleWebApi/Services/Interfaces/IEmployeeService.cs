using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleWebApi.Dtos;

namespace SimpleWebApi.Services.Interfaces
{
	public interface IEmployeeService
	{
		Task<PagedList<EmployeeDTO>> GetEmployees(int page = 1, int pageSize = 10);
	}
}
