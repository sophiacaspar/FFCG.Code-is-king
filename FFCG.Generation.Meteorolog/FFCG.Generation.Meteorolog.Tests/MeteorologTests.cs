using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Globalization;

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
        private List<DailyValues> _dailyValues;

        [TestInitialize]
        public void SetUp()
        {
            _meteorolog = new Meteorolog();
            _unixTimestampConverter = new UnixTimestampConverter();
            _dailyValues = new List<DailyValues>();

            /////////////////////////////////////////////
            DailyValues _dailyvalues1 = new DailyValues
            {
                Date = "2017-11-27",
                Time = "10:00:00",
                Temperature = float.Parse("3.2", CultureInfo.InvariantCulture.NumberFormat)
            };
            _dailyValues.Add(_dailyvalues1);

            DailyValues _dailyvalues2 = new DailyValues
            {
                Date = "2017-11-27",
                Time = "21:30:00",
                Temperature = float.Parse("-0.1", CultureInfo.InvariantCulture.NumberFormat)
            };
            _dailyValues.Add(_dailyvalues2);

            DailyValues _dailyvalues3 = new DailyValues
            {
                Date = "2017-11-28",
                Time = "12:15:00",
                Temperature = float.Parse("7.1", CultureInfo.InvariantCulture.NumberFormat)
            };
            _dailyValues.Add(_dailyvalues3);

            //////////////////////////////////////////////

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
