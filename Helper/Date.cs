using System;

namespace heinousHorror.Helper
{
    public static class DateToUnix
    {
        public static long GetUnixTime(DateTime date)
        {
            long unixTime = ((DateTimeOffset) date).ToUnixTimeSeconds();
            return unixTime;
        }
    }
}