using DDDParttern.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Infrastructure.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }
        public DbSet<Departments> DepartmentsModel { get; set; }
    }
}
