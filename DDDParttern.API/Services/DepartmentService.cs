using DDDParttern.Domain.Entities;
using DDDParttern.Domain.IRepository;
using DDDParttern.API.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Departments> DepartmentRepo;
        private readonly IRepositoryReadonly<Departments> DepartmentRepoReadonly;
        public DepartmentService(IRepositoryReadonly<Departments> departmentRepoReadonly, IRepository<Departments> departmentRepo) {
            DepartmentRepo = departmentRepo;
            DepartmentRepoReadonly = departmentRepoReadonly;
        }

        async public Task<List<Departments>> GetAll()
        {
            return await DepartmentRepoReadonly.GetAll().ToListAsync();
        }

        async public Task Create(Departments departments)
        {

            await DepartmentRepo.Create(departments);
        }

        async public Task<Departments> GetByName(string name)
        {
            Departments departments = await DepartmentRepoReadonly.GetByQuery(i => i.Name == name).FirstOrDefaultAsync();
            return departments ?? null;
        }
    }
}
