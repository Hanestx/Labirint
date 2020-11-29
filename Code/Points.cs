namespace Labirint
{
    public static class Points
    {
        public static int _pointCount { get; private set; }
        public static int _pointWinCount { get; private set; } = 30;

        public static int PointsCount(int value)
        {
            return _pointCount += value;
        }
    }
}