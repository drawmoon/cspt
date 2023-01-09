using System;
using SimpleWebApi.DbContexts;
using SimpleWebApi.Models.Management;
using SimpleWebApi.Repositories.Interfaces;

namespace SimpleWebApi.Repositories
{
	public class EmployeeRepository : RepositoryBase<Employee, int>, IEmployeeRepository
    {
		public EmployeeRepository(ManagementDbContext dbContext) : base(dbContext)
		{
		}
	}
}
