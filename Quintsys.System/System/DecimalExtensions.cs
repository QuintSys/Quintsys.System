namespace Quintsys.System
{
    public static class DecimalExtensions
    {
        public static decimal SqlSafeDecimalValue(this decimal decimalValue)
        {
            // see https://msdn.microsoft.com/en-us/library/ms179882(v=sql.110).aspx
            const decimal sqlMoneyMinimumValue = -922337203685477.5808M;
            const decimal sqlMoneyMaximumDecimal = 922337203685477.5807M;

            if (decimalValue < sqlMoneyMinimumValue)
                decimalValue = sqlMoneyMinimumValue;

            if (decimalValue > sqlMoneyMaximumDecimal)
                decimalValue = sqlMoneyMaximumDecimal;
            
            return decimalValue;
        }
    }
}