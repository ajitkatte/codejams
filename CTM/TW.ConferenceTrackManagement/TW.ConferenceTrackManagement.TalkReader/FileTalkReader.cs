using System.Collections.Generic;
using System.IO;
using System.Linq;
using TW.ConferenceTrackManagement.Contract;

namespace TW.ConferenceTrackManagement.TalkReader
{
    public class FileTalkReader : ITalkReader
    {
        private readonly string _fileName;

        public FileTalkReader(string fileName)
        {
            _fileName = fileName;
        }
        public List<string> Read()
        {
            try
            {
                return File.ReadAllLines(_fileName).ToList();
            }
            catch (FileNotFoundException exception)
            {
                throw;
            }
        }
    }
}
