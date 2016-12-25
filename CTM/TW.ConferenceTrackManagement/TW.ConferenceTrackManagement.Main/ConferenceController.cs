using System;
using TW.ConferenceTrackManagement.Contract;
using TW.ConferenceTrackManagement.Parser;
using TW.ConferenceTrackManagement.SchedulePrinter;
using TW.ConferenceTrackManagement.Scheduler;
using TW.ConferenceTrackManagement.TalkReader;

namespace TW.ConferenceTrackManagement.Main
{
    class ConferenceController
    {
        static void Main(string[] args)
        {
            try
            {
                string talkFileName = AppDomain.CurrentDomain.BaseDirectory + "\\talks.txt";
                ITalkParser talkParser = new DefaultTalkParser(new FileTalkReader(talkFileName));
                var talks = talkParser.Parse();
                IConferenceScheduler scheduler = new ConferenceScheduler();
                var conference = scheduler.Schedule(talks);
                IConferenceSchedulePrinter schedulePrinter = new LunchBreakHighlighter(new ConsoleConferenceSchedulePrinter());
                schedulePrinter.Print(conference);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error occurred while scheduling conference. \n" + exception.StackTrace);
            }
            Console.ReadLine();
        }
    }
}
