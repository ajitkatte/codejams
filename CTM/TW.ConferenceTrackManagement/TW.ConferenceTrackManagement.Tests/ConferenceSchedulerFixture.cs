using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.ConferenceTrackManagement.Contract;
using TW.ConferenceTrackManagement.Scheduler;

namespace TW.ConferenceTrackManagement.Tests
{
    [TestClass]
    public class ConferenceSchedulerFixture
    {
        private IConferenceScheduler _scheduler;

        [TestInitialize]
        public void Init()
        {
            _scheduler = new ConferenceScheduler();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestScheduleTalksWithInvalidInput()
        {
            _scheduler.Schedule(null);
        }

        [TestMethod]
        public void TestScheduleTalkWithValidInput()
        {
            var talks = TalkProvider.GetTalks();
            var conference = _scheduler.Schedule(talks);
            Assert.IsNotNull(conference);
            Assert.IsNotNull(conference.Tracks);
            Assert.IsTrue(conference.Tracks.Count > 0);
            Assert.IsTrue(conference.Tracks.Any(t => t.Events != null && t.Events.Count > 0));
        }
    }
}
