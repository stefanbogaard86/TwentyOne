namespace TwentyOne.Converters
{
    public static class IntExtensions
    {
        public static string ToWord(this int intValue)
        {
            if (intValue == 1)
                return "one";
            if (intValue == 2)
                return "two";
            if (intValue == 3)
                return "three";
            if (intValue == 4)
                return "four";
            if (intValue == 5)
                return "five";
            if (intValue == 6)
                return "six";

            return "";
        }
    }
}