using LupExercise.Entities;
using LupExercise.Repository;
using System.Collections.Generic;
using System;

namespace LupExercise.Services
{
    public interface IEventService
    {
        // It really is a struggle when 'event' term is reserved for another VS functionality already
        public IEnumerable<Event> GetAllEvents();
        public void UpdateEvent(Event changedEvent);
        public void CreateEvent(Event newEvent);
        public void DeleteEventById(int id);
    }

    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepository.GetAll();
        }

        public void UpdateEvent(Event changedEvent)
        {
            var eventToUpdate = _eventRepository.Get(changedEvent.EventId);
            eventToUpdate = changedEvent;
            eventToUpdate.ModifiedDate = DateTime.UtcNow;
            _eventRepository.SaveChanges();
        }

        public void CreateEvent(Event newEvent)
        {
            newEvent.CreatedDate = DateTime.UtcNow;
            newEvent.ModifiedDate = DateTime.UtcNow;
            _eventRepository.Add(newEvent);
        }

        public void DeleteEventById(int id)
        {
            _eventRepository.DeleteById(id);
        }
    }
}