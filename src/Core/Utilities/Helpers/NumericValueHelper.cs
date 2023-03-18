namespace Core.Utilities.Helpers
{
    public static class NumericValueHelper
    {
        public static decimal GetNonNegatifValue(this decimal value)
        {
            return value >= 0 ? value : 0;
        }
        public static int GetNonNegatifValue(this int value)
        {
            return value >= 0 ? value : 0;
        }
    }
}
