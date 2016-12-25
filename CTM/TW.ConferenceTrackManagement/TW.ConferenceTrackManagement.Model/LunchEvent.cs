namespace TW.ConferenceTrackManagement.Model
{
    public class LunchEvent : Event
    {
        public LunchEvent()
        {
            Topic = "Lunch";
            TimeSlotInMinutes = 60;
        }
    }
}
