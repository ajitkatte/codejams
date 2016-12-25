using System;
using System.Collections.Generic;
using System.Linq;
using TW.ConferenceTrackManagement.Contract;
using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.Scheduler
{
    public class ConferenceScheduler : IConferenceScheduler
    {
        private readonly int _firstHalfTotalMinutes = 180;
        private readonly int _secondHalfTotalMinutes = 240;

        public Conference Schedule(List<Talk> talks)
        {
            if (AreTalksValid(talks))
            {
                var tracks = new List<Track>();
                var tracker = DateTime.Today;

                while (talks.Count(t => t.Scheduled == false) > 0)
                {
                    tracker = InitializeTracker(tracker);
                    Track track = InitializeTrack();
                    ScheduleHalf(track, talks, ref tracker, _firstHalfTotalMinutes);
                    ScheduleLunchBreak(track, ref tracker);
                    tracker = tracker.AddHours(1);
                    ScheduleHalf(track, talks, ref tracker, _secondHalfTotalMinutes);
                    ScheduleNetWorking(track, ref tracker);
                    tracks.Add(track);
                }
                return new Conference { Tracks = tracks };
            }
            throw new ArgumentNullException("talks");
        }

        private static DateTime InitializeTracker(DateTime tracker)
        {
            tracker = tracker.AddDays(1);
            tracker = new DateTime(tracker.Year, tracker.Month, tracker.Day, 9, 0, 0);
            return tracker;
        }

        private void ScheduleNetWorking(Track track, ref DateTime tracker)
        {
            var lunchEvent = new NetworkingEvent
            {
                Schedule = tracker,
            };
            track.Events.Add(lunchEvent);
        }

        private void ScheduleLunchBreak(Track track, ref DateTime tracker)
        {
            tracker = new DateTime(tracker.Year, tracker.Month, tracker.Day, 12, 0, 0);
            var lunchEvent = new LunchEvent
            {
                Schedule = tracker,
            };
            track.Events.Add(lunchEvent);
        }

        private Track InitializeTrack()
        {
            return new Track
            {
                Events = new List<Event>()
            };
        }

        private void ScheduleHalf(Track track, List<Talk> talks, ref DateTime tracker, int totalMinutesInHalf)
        {
            while (totalMinutesInHalf > 0)
            {
                var talk = talks.Find(t => t.Scheduled == false && t.TimeSlotInMinutes <= totalMinutesInHalf);
                if (talk == null)
                {
                    return;
                }
                var talkEvent = CreateTalkEvent(tracker, talk);
                track.Events.Add(talkEvent);
                tracker = tracker.AddMinutes(talk.TimeSlotInMinutes);
                totalMinutesInHalf -= talkEvent.TimeSlotInMinutes;
                talk.Scheduled = true;
            }
        }

        private static TalkEvent CreateTalkEvent(DateTime tracker, Talk talk)
        {
            var talkEvent = new TalkEvent
            {
                TimeSlotInMinutes = talk.TimeSlotInMinutes,
                Schedule = tracker,
                Topic = talk.Subject,
                Presenter = "Mr. X"
            };
            return talkEvent;
        }

        private static bool AreTalksValid(List<Talk> talks)
        {
            return talks != null && talks.Count > 0;
        }
    }
}
