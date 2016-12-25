namespace TW.ConferenceTrackManagement.Model
{
    public class NetworkingEvent : Event
    {
        public NetworkingEvent()
        {
            Topic = "Networking Event";
            TimeSlotInMinutes = 60;
        }
    }
}
