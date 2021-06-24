﻿using LupExercise.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LupExercise.Repository
{
    public interface IDbRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void SaveChanges();
    }

    public class DbRepository<T> : IDbRepository<T> where T : class
    {
        public LupExerciseContext Db;

        public DbRepository(LupExerciseContext db)
        {
            Db = db;
        }
        public virtual T Get(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Db.Set<T>().AsEnumerable();
        }

        public virtual void Add(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
        }

        public virtual void Remove(T entity)
        {
            Db.Set<T>().Remove(entity);
            Db.SaveChanges();
        }

        public virtual void SaveChanges()
        {
            Db.SaveChanges();
        }
    }
}
