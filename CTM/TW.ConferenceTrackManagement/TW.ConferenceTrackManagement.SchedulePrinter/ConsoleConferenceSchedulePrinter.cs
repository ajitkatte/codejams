using System;
using TW.ConferenceTrackManagement.Contract;
using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.SchedulePrinter
{
    public class ConsoleConferenceSchedulePrinter : IConferenceSchedulePrinter
    {
        public void Print(Conference conference)
        {
            if (IsValid(conference))
            {
                int trackCounter = 1;
                foreach (var track in conference.Tracks)
                {
                    Console.WriteLine("Track " + trackCounter);
                    foreach (var dailyEvent in track.Events)
                    {
                        Console.WriteLine(dailyEvent.ToString());
                    }
                    trackCounter++;
                }
            }
            else
            {
                throw new ArgumentException("Invalid conference.");
            }
        }

        private static bool IsValid(Conference conference)
        {
            return conference != null && conference.Tracks != null && conference.Tracks.Count > 0;
        }
    }
}
