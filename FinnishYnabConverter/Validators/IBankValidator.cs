namespace FinnishYnabConverter.Validators
{
    using System;
    using System.Collections;
    public interface IBankValidator
    {
        void Validate(InputFileInformation inputFileInformation);
    }
}