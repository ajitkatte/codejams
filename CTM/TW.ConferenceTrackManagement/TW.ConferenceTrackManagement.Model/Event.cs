using System;
using System.Globalization;

namespace TW.ConferenceTrackManagement.Model
{
    public abstract class Event
    {
        public int TimeSlotInMinutes { get; set; }
        public string Topic { get; set; } 
        public DateTime Schedule { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Schedule.ToString("hh:mm tt", CultureInfo.InvariantCulture), Topic);
        }
    }
}
