using System.Collections.Generic;
using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.Contract
{
    public interface IConferenceScheduler
    {
        Conference Schedule(List<Talk> talk);
    }
}
