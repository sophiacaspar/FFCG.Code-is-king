using Microsoft.VisualStudio.TestTools.UnitTesting;

/**
 * 
 * Datum,klockslag och temperatur för första gången det rapporterades att det var minusgrader
 * Datum, klockslag och temperatur för den kallaste temperaturen
 * Datum, klockslag och temperatur för den varmaste temperaturen
 * Ett snitt för hur temperaturen varit, per dag, för de dagar som finns med i den data som ni ska jobba med
 * Bygg en applikation som kan analyzera en datamängd från en fil på disk och presentera ovanstående saker.
 * */

namespace FFCG.Generation.Meteorolog.Tests
{
    [TestClass]
    public class MeteorologTests
    {
        private Meteorolog _meteorolog;
        private UnixTimestampConverter _unixTimestampConverter;

        [TestInitialize]
        public void SetUp()
        {
            _meteorolog = new Meteorolog();
            _unixTimestampConverter = new UnixTimestampConverter();
        }

        [TestMethod]
        public void Should_convert_unixtimestamp_to_date()
        {
            long unixTimestamp = 1511776800;
            string dateCorrespondingToUnixTimestamp = "2017-11-27";
            string date = _unixTimestampConverter.GetDateFromTimestamp(unixTimestamp);
            Assert.AreEqual(dateCorrespondingToUnixTimestamp, date);
        }

        [TestMethod]
        public void Should_convert_unixtimestamp_to_time()
        {
            long unixTimestamp = 1511776800;
            string timeCorrespondingToUnixTimestamp = "10:00:00";
            string date = _unixTimestampConverter.GetTimeFromTimestamp(unixTimestamp);
            Assert.AreEqual(timeCorrespondingToUnixTimestamp, date);
        }
    }
}
