using System;
using System.ComponentModel.DataAnnotations;

namespace LupExercise.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventTimezone { get; set; }
        public DateTime? StartDate { get; set; } //Only made these nullable for validation cheecks, otherwise posts will automatically generate a default date if not specified
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}