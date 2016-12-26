using System;
using System.IO;
using TW.ConferenceTrackManagement.Contract;
using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.SchedulePrinter
{
    public class FileConferenceSchedulePrinter : IConferenceSchedulePrinter
    {
        private string _fileName;

        public FileConferenceSchedulePrinter(string fileName)
        {
            _fileName = fileName;
        }
        public void Print(Conference conference)
        {
            int trackCounter = 1; 
            foreach (var track in conference.Tracks)
            {
                File.AppendAllText(_fileName, "Track "+trackCounter+Environment.NewLine);
                foreach (var dailyEvent in track.Events)
                {
                    File.AppendAllText(_fileName, dailyEvent.ToString());
                }
                File.AppendAllText(_fileName, Environment.NewLine);
                trackCounter++;
            }
        }
    }
}
