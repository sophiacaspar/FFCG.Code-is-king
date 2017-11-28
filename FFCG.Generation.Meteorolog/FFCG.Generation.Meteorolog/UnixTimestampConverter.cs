using System;
using System.Collections.Generic;
using System.Text;

namespace FFCG.Generation.Meteorolog
{
    public class UnixTimestampConverter
    {
        public string GetDateFromTimestamp(long unixTimestamp)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            string format = "yyyy-MM-dd";
            var timestamp = epoch.AddSeconds(unixTimestamp);

            return timestamp.ToString(format);
        }

        public string GetTimeFromTimestamp(long unixTimestamp)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            string format = "hh:mm:ss";
            var timestamp = epoch.AddSeconds(unixTimestamp);

            return timestamp.ToString(format);
        }
    }
}
