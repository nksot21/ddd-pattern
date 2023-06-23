﻿using DDDParttern.Domain.Entities;
using DDDParttern.Domain.IRepository;
using DDDParttern.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Infrastructure.Repository
{
    public class RepositoryReadonly<T> : IRepositoryReadonly<T> where T: class, IBaseEntity
    {
        private readonly SQLServerContextReadonly SQLContext;
        private  DbSet<T> Entities;
        public RepositoryReadonly(SQLServerContextReadonly context) { 
            SQLContext = context;
            Entities =  SQLContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return Entities.Where(i => i.DeletedAt == null);
        }

        public async Task Create(T entities)
        {
            await Entities.AddAsync(entities);
            await SQLContext.SaveChangesAsync();
        }

        public IQueryable<T> GetByQuery(Expression<Func<T, bool>> query)
        {
            return Entities.Where(query).Where(i => i.DeletedAt == null);
        }

        public IQueryable<T> GetByQueryPaged(Expression<Func<T, bool>> query, int pageSize = 0, int pageNumber = 0)
        {
            if (pageSize != 0 && pageNumber != 0)
            {
                return Entities.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).Where(query).Where(i => i.DeletedAt == null);
            }
            return Entities.Where(query);
        }
    }
}
