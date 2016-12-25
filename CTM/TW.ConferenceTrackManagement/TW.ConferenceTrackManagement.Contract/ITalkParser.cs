using System;
using System.Collections.Generic;
using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.Contract
{
    public interface ITalkParser
    {
        List<Talk> Parse();
    }
}
