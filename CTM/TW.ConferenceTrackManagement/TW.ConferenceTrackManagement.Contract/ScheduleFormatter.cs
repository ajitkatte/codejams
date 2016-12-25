using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.Contract
{
    public abstract class ScheduleFormatter : IConferenceSchedulePrinter
    {
        private readonly IConferenceSchedulePrinter _schedulePrinter;

        protected ScheduleFormatter(IConferenceSchedulePrinter schedulePrinter)
        {
            _schedulePrinter = schedulePrinter;
        }

        public virtual void Print(Conference conference)
        {
            _schedulePrinter.Print(conference);
        }
    }
}
