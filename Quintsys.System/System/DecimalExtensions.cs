namespace Quintsys.System
{
    public static class DecimalExtensions
    {
        // see https://msdn.microsoft.com/en-us/library/ms179882(v=sql.110).aspx
        public const decimal SqlMoneyMinimumValue = -922337203685477.5808M;
        public const decimal SqlMoneyMaximumDecimal = 922337203685477.5807M;

        public static decimal SqlSafeDecimalValue(this decimal decimalValue)
        {
            if (decimalValue < SqlMoneyMinimumValue)
                decimalValue = SqlMoneyMinimumValue;

            if (decimalValue > SqlMoneyMaximumDecimal)
                decimalValue = SqlMoneyMaximumDecimal;

            return decimalValue;
        }
    }
}