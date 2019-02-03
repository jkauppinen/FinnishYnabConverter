namespace FinnishYnabConverter.Factories
{
    using global::FinnishYnabConverter.Validators;
    public interface IBankValidatorFactory
    {
        IBankValidator CreateBankValidator(InputFileInformation inputFileInformation);
    }
}