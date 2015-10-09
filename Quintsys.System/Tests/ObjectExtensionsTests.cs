using NUnit.Framework;

namespace Quintsys.System.Tests
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
        public static void Should_Convert_Non_Nullable_Types()
        {
            const int nonNullable = 1;
            decimal converted = nonNullable.ChangeType<decimal>();

            Assert.IsInstanceOf<decimal>(converted);
        }

        [Test]
        public static void Should_Convert_Nullable_Types()
        {
            int? nonNullable = 1;
            decimal? converted = nonNullable.ChangeType<decimal?>();

            Assert.IsInstanceOf<decimal?>(converted);
        }

        [Test]
        public static void Should_Return_Default_Values_For_Nulls()
        {
            decimal? converted = ((int?) null).ChangeType<decimal?>();

            Assert.AreEqual(default(int?), converted);
        }
    }
}