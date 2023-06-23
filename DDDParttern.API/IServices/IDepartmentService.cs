using DDDParttern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.API.IServices
{
    public interface IDepartmentService
    {
        public Task<List<Departments>> GetAll();

        public Task Create(Departments departments);

        public Task<Departments> GetByName(string name);
    }
}
