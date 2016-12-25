using System.Collections.Generic;

namespace TW.ConferenceTrackManagement.Contract
{
    public interface ITalkReader
    {
        List<string> Read();
    }
}
