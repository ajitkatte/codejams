using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.ConferenceTrackManagement.Contract;
using TW.ConferenceTrackManagement.Parser;
using TW.ConferenceTrackManagement.TalkReader;

namespace TW.ConferenceTrackManagement.Tests
{
    [TestClass]
    public class TalkParserFixture
    {
        private ITalkParser _parser;

        [TestInitialize]
        public void Init()
        {
            _parser = new DefaultTalkParser(new FileTalkReader(AppDomain.CurrentDomain.BaseDirectory + "\\talks.txt"));
        }

        [TestMethod]
        public void TestTalkParser()
        {
            var talks = _parser.Parse();
            Assert.IsNotNull(talks);
            Assert.IsTrue(talks.Count > 0);
        }
    }
}
