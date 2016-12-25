namespace TW.ConferenceTrackManagement.Model
{
    public class Talk
    {
        public TalkType Type { get; set; }

        public string Subject { get; set; }

        public int TimeSlotInMinutes { get; set; }

        public bool Scheduled { get; set; }
    }
}
