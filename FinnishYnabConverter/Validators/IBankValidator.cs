namespace FinnishYnabConverter.Validators
{
    using System;
    using System.Collections;
    using global::FinnishYnabConverter.Inputs;

    public interface IBankValidator
    {
        void Validate(InputFileInformation inputFileInformation);
    }
}