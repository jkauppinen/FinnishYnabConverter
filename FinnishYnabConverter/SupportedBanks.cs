namespace FinnishYnabConverter
{
    using System.Collections.Generic;

    public static class SupportedBanks
    {
        public const string OP = "OP";
        public const string Handelsbanken = "Handelsbanken";
        public static IEnumerable<string> Collection = new string[]{OP,Handelsbanken};
    }
}