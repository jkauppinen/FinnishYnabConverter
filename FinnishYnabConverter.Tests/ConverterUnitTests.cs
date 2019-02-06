/*
    Unit test naming conventions follow
    MethodName_StateUnderTest_ExpectedBehavior
 */

namespace FinnishYnabConverter.Tests
{
    using System;
    using Xunit;
    using global::FinnishYnabConverter;
    public class UnitTest1
    {

        [Fact]
        public void Validate_Valid_Transactions()
        {

            string[] validTransactions = Transactions.CreateValidTransactions();
            Assert.Equal(30, validTransactions.Length);
        }

        private IFinnishYnabConverter CreateFinnishYnabConverter()
        {
            throw new NotImplementedException();
        }

    }
}
