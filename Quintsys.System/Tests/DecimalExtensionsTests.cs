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
            decimal result = decimal.MinValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: SqlMoneyMinimumValue, actual: result);
        }

        [Test]
        public void Values_Greater_Than_SQL_Money_Maximum_Should_Be_Changed_To_SQL_Money_Maximum()
        {
            decimal result = decimal.MaxValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: SqlMoneyMaximumDecimal, actual: result);
        }

        [Test]
        public void Values_Greater_Than_SQL_Money_Minimum_And_Smaller_Than_SQL_Money_Maximum_Should_Not_Change(
            [Random((double) SqlMoneyMinimumValue, (double) SqlMoneyMaximumDecimal, 1)] decimal randomDecimalValue)
        {
            decimal result = randomDecimalValue.SqlSafeDecimalValue();

            Assert.AreEqual(expected: randomDecimalValue, actual: result);
        }
    }
}