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
                Time = "06:15:00",
                Temperature = float.Parse("-3.7", CultureInfo.InvariantCulture.NumberFormat)
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

        [TestMethod]
        public void Should_get_the_first_occurrence_below_zero()
        {
            DailyValues firstBelowZero = _meteorolog.GetFirstOccurrenceOfBelowZero(_dailyValues);
            float temperature = float.Parse("-0.1", CultureInfo.InvariantCulture.NumberFormat);
            Assert.AreEqual(temperature, firstBelowZero.Temperature);
        }

        [TestMethod]
        public void Should_get_the_coldest_temperature()
        {
            DailyValues coldest = _meteorolog.GetColdestOccurrence(_dailyValues);
            float temperature = float.Parse("-3.7", CultureInfo.InvariantCulture.NumberFormat);
            Assert.AreEqual(temperature, coldest.Temperature);
        }

        [TestMethod]
        public void Should_get_the_warmest_temperature()
        {
            DailyValues warmest = _meteorolog.GetWarmestOccurrence(_dailyValues);
            float temperature = float.Parse("3.2", CultureInfo.InvariantCulture.NumberFormat);
            Assert.AreEqual(temperature, warmest.Temperature);
        }

        [TestMethod]
        public void Should_get_the_average_temperature_per_day()
        {
            var average = _meteorolog.GetAverageTemperaturePerDay(_dailyValues);
            float temp1 = float.Parse("3.2", CultureInfo.InvariantCulture.NumberFormat);
            float temp2 = float.Parse("-0.1", CultureInfo.InvariantCulture.NumberFormat);
            float averageTemp1 = (temp1 + temp2) / 2;
            Assert.AreEqual(averageTemp1, average[0].Temperature);

            float averageTemp2 = float.Parse("-3.7", CultureInfo.InvariantCulture.NumberFormat);
            Assert.AreEqual(averageTemp2, average[1].Temperature);

        }
    }
}
