namespace NotEnoughMemory.Model.Tools
{
    public static class ComparableUtils
    {
        public static int TryThrowLessThanOrEqualsToZeroException(this int number)
        {
            if (number <= 0)
                throw new LessThanOrEqualsToZeroException(nameof(number));

            return number;
        }

        public static float TryThrowLessOrEqualsToZeroException(this float number)
        {
            if (number <= 0)
                throw new LessThanOrEqualsToZeroException(nameof(number));

            return number;
        }
    }
}
