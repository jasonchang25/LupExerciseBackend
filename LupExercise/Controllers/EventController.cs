using LupExercise.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System;
using LupExercise.Entities;

namespace LupExercise.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            try
            {
                var events = _eventService.GetAllEvents();
                return Ok(events);
            }
            catch
            {
                return BadRequest(new { message = "error has occured when attempting to get events" });
            }
        }

        [HttpPost]
        public IActionResult CreateEvent(Event newEvent)
        {
            newEvent.CreatedDate = DateTime.UtcNow;
            newEvent.ModifiedDate = DateTime.UtcNow;
            var validCheck = ValidateEvent(newEvent);
            if (validCheck != null) return validCheck;

            try
            {
                _eventService.CreateEvent(newEvent);
                return Ok(new { message = "event has been successfully created" });
            }
            catch
            {
                return BadRequest(new { message = "error has occured when attempting to create event" });
            }
        }

        [HttpPost]
        public IActionResult UpdateEvent(Event changedEvent)
        {
            changedEvent.ModifiedDate = DateTime.UtcNow;
            var validCheck = ValidateEvent(changedEvent);
            if (validCheck != null) return validCheck;

            try
            {
                _eventService.UpdateEvent(changedEvent);
                return Ok(new { message = "event has been successfully updated" });
            }
            catch
            {
                return BadRequest(new { message = "error has occured when attempting to update event" });
            }
        }

        [HttpPost]
        public IActionResult DeleteEventById(int id)
        {
            try
            {
                _eventService.DeleteEventById(id);
                return Ok(new { message = "event has been successfully deleted" });
            }
            catch
            {
                return BadRequest(new { message = "error has occured when attempting to delete event" });
            }
        }

        private IActionResult ValidateEvent(Event eventToValidate)
        {
            if (String.IsNullOrEmpty(eventToValidate.EventName))
            {
                return BadRequest(new { message = "Event name must be specified" });
            }

            if (String.IsNullOrEmpty(eventToValidate.EventDescription))
            {
                return BadRequest(new { message = "Event description must be specified" });
            }

            if (eventToValidate.StartDate == null)
            {
                return BadRequest(new { message = "Event start date must be specified" });
            }

            if (eventToValidate.EndDate == null)
            {
                return BadRequest(new { message = "Event start date must be specified" });
            }

            if (eventToValidate.StartDate > eventToValidate.EndDate)
            {
                return BadRequest(new { message = "Event end date must be after start date" });
            }

            return null;
        }

    }
}
