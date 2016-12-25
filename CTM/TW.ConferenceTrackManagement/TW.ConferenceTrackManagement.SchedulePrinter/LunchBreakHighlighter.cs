using System.Linq;
using TW.ConferenceTrackManagement.Contract;
using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.SchedulePrinter
{
    public class LunchBreakHighlighter : ScheduleFormatter
    {
        public LunchBreakHighlighter(IConferenceSchedulePrinter conferencePrinter) : base(conferencePrinter)
        {
        }

        public override void Print(Conference conference)
        {
            var events = conference.Tracks.SelectMany(t => t.Events);
            foreach (var ev in events)
            {
                if (ev is LunchEvent)
                {
                    ev.Topic = "*** "+ev.Topic + " ***";
                }
            }
            base.Print(conference);
        }
    }
}
