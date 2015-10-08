using NUnit.Framework;

namespace Quintsys.System.Tests
{
    [TestFixture]
    public class DecimalExtensionsTests
    {
        const decimal SqlMoneyMinimumValue = -922337203685477.5808M;
        const decimal SqlMoneyMaximumDecimal = 922337203685477.5807M;

        [Test]
        public void Decimal_Values_Smaller_Than_SQL_Money_Minimum_Value_Should_Be_Changed_To_SQL_Money_Minimum_Value()
        {
            decimal result = (SqlMoneyMinimumValue - 1M).SqlSafeDecimalValue();

            Assert.AreEqual(expected: SqlMoneyMinimumValue, actual: result);
        }

        [Test]
        public void Decimal_Values_Greater_Than_SQL_Money_Maximum_Value_Should_Be_Changed_To_SQL_Money_Maximum_Value()
        {
            decimal result = (SqlMoneyMaximumDecimal + 1M).SqlSafeDecimalValue();

            Assert.AreEqual(expected: SqlMoneyMaximumDecimal, actual: result);
        }
    }
}