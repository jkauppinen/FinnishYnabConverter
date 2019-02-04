namespace FinnishYnabConverter.Factories
{
    using global::FinnishYnabConverter.Inputs;
    using global::FinnishYnabConverter.Validators;
    public interface IBankValidatorFactory
    {
        IBankValidator CreateBankValidator(InputFileInformation inputFileInformation);
    }
}