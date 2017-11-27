using Microsoft.VisualStudio.TestTools.UnitTesting;

/**
 * 
 * Datum,klockslag och temperatur f�r f�rsta g�ngen det rapporterades att det var minusgrader
 * Datum, klockslag och temperatur f�r den kallaste temperaturen
 * Datum, klockslag och temperatur f�r den varmaste temperaturen
 * Ett snitt f�r hur temperaturen varit, per dag, f�r de dagar som finns med i den data som ni ska jobba med
 * Bygg en applikation som kan analyzera en datam�ngd fr�n en fil p� disk och presentera ovanst�ende saker.
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
