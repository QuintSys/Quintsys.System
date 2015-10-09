using System;
using NUnit.Framework;
using static Quintsys.System.DecimalExtensions;

namespace Quintsys.System.Tests
{
    [TestFixture]
    public class DecimalExtensionsTests
    {
        [Test]
        public void Values_Smaller_Than_SQL_Money_Minimum_Should_Be_Changed_To_SQL_Money_Minimum()
        {
            const decimal smallDecimalValue = (SqlMoneyMinimumValue - 1.0M);

            decimal result = smallDecimalValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: SqlMoneyMinimumValue, actual: result);
        }

        [Test]
        public void Values_Greater_Than_SQL_Money_Maximum_Should_Be_Changed_To_SQL_Money_Maximum()
        {
            const decimal largeDecimalValue = (SqlMoneyMaximumDecimal + 1.0M);

            decimal result = largeDecimalValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: SqlMoneyMaximumDecimal, actual: result);
        }

        [Test]
        public void Values_Greater_Than_SQL_Money_Minimum_And_Smaller_Than_SQL_Money_Maximum_Should_Not_Change()
        {
            var random = new Random();
            decimal randomDecimalValue = random.RandomDecimal(SqlMoneyMaximumDecimal, SqlMoneyMinimumValue);

            decimal result = randomDecimalValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: randomDecimalValue, actual: result);
        }
    }
}