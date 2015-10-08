using System;
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
            decimal smallDecimalValue = (SqlMoneyMinimumValue - 1M);

            decimal result = smallDecimalValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: SqlMoneyMinimumValue, actual: result);
        }

        [Test]
        public void Decimal_Values_Greater_Than_SQL_Money_Maximum_Value_Should_Be_Changed_To_SQL_Money_Maximum_Value()
        {
            decimal largeDecimalValue = (SqlMoneyMaximumDecimal + 1M);

            decimal result = largeDecimalValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: SqlMoneyMaximumDecimal, actual: result);
        }

        [Test]
        public void Decimal_Values_Greater_Than_SQL_Money_Minimum_Value_And_Smaller_Than_SQL_Money_Maximum_Value_Should_Not_Change()
        {
            Random random = new Random();
            var safeRandomDecimalValue = (decimal) (random.NextDouble() * (double) (SqlMoneyMaximumDecimal - SqlMoneyMinimumValue) + (double) SqlMoneyMinimumValue);
            
            decimal result = safeRandomDecimalValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: safeRandomDecimalValue, actual: result);
        }
    }
}