using NUnit.Framework;
using Sigma.Core.Extensions;

namespace Sigma.General.Tests
{
    [TestFixture]
    public class CoreHelpers
    {
        [Test]
        public void Convert_Decimal_Or_Return_Default_Good_Input()
        {
            var result = "0.0023".GetValueOrDefault<decimal>(0.01m);

            Assert.That(result == 0.0023m);
        }

        [Test]
        public void Convert_Decimal_Or_Return_Default_Bad_Input()
        {
            var result = "0.ax023".GetValueOrDefault<decimal>(0.01m);

            Assert.That(result == 0.01m);
        }

    }
}
