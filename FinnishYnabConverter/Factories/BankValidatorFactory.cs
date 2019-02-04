namespace FinnishYnabConverter.Factories
{
    using System;
    using global::FinnishYnabConverter.Inputs;
    using global::FinnishYnabConverter.Validators;

    public class BankValidatorFactory : IBankValidatorFactory
    {
        public IBankValidator CreateBankValidator(InputFileInformation inputFileInformation)
        {
            if (inputFileInformation.BankName.Trim().Equals(SupportedBanks.Handelsbanken, StringComparison.OrdinalIgnoreCase)
            || inputFileInformation.BankName.Trim().Equals(SupportedBanks.OP, StringComparison.OrdinalIgnoreCase))
            {
                return new PathValidator();
            }
            else
                throw new ArgumentException("Bank {0} is not supported");
        }
    }
}