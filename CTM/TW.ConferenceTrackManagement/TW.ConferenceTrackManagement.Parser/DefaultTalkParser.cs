using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TW.ConferenceTrackManagement.Contract;
using TW.ConferenceTrackManagement.Model;

namespace TW.ConferenceTrackManagement.Parser
{
    public class DefaultTalkParser : ITalkParser
    {
        private readonly ITalkReader _talkReader;

        public DefaultTalkParser(ITalkReader talkReader)
        {
            _talkReader = talkReader;
        }
        public List<Talk> Parse()
        {
            var talks = new List<Talk>();
            var talkLines = _talkReader.Read();
            foreach (var talkLine in talkLines)
            {
                Talk talk;
                if (IsLightningTalk(talkLine))
                {
                    talk = CreateTalk(talkLine, TalkType.Ligtening, 5);
                }
                else
                {
                    int talkMinutes = GetTalkMinutes(talkLine);
                    talk = CreateTalk(talkLine, TalkType.Minutes, talkMinutes);

                }
                if (talk != null)
                {
                    talks.Add(talk);
                }
                else
                {
                    throw new ArgumentException("Invalid talk");
                }
            }
            return talks;
        }

        private int GetTalkMinutes(string talkLine)
        {
            return Convert.ToInt32(Regex.Match(talkLine, @"\d+").Value);
        }

        private static Talk CreateTalk(string talkLine, TalkType talkType, int minutes)
        {
            var talk = new Talk
            {
                Type = talkType,
                Subject = talkLine,
                TimeSlotInMinutes = minutes
            };
            return talk;
        }

        private bool IsLightningTalk(string talkLine)
        {
            return talkLine.Contains("lightning");
        }
    }
}
