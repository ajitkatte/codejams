using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.Contract
{
    public interface IConferenceSchedulePrinter
    {
        void Print(Conference conference);
    }
}
