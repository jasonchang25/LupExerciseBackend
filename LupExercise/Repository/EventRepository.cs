using LupExercise.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LupExercise.Repository
{
    public interface IEventRepository : IDbRepository<Event>
    {
        public void DeleteById(int id);
    }

    public class EventRepository : DbRepository<Event>, IEventRepository
    {
        public EventRepository(LupExerciseContext db) : base(db)
        {  
        }

        public void DeleteById(int id)
        {
            var eventToDelete = Db.Events.Find(id);
            if (eventToDelete == null)
            {
                throw new Exception("Unable to find valid event to delete");
            }

            Db.Events.Remove(eventToDelete);
        }
    }
}
