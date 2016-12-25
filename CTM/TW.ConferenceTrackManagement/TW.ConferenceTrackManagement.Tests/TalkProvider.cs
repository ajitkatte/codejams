using System.Collections.Generic;
using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.Tests
{
    internal class TalkProvider
    {
        public static List<Talk> GetTalks()
        {
            return new List<Talk>
            {
                new Talk
                {
                    TimeSlotInMinutes = 45,
                    Subject = "Scala for Beginers 45min",
                    Type = TalkType.Minutes
                },
                new Talk
                {
                    TimeSlotInMinutes = 60,
                    Subject = "C# in depth by Jon Skeet 60min",
                    Type = TalkType.Minutes
                },
                new Talk
                {
                    TimeSlotInMinutes = 5,
                    Subject = "Introduction to AWS Dev Day lightning",
                    Type = TalkType.Ligtening
                }
            };
        } 
    }
}
