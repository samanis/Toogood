using System;
using Toogood.Saman.Transform.Model;
using Toogood.Saman.Transform.Model.Input;
using Toogood.Saman.Transform.Model.Target;

namespace Toogood.Saman.Transform.AppService
{
    public class TargetFileFactory : ITargetFileFactory
    {
        public TargetFile CreateTargetFile(IInputFile inputFileBase)
        {
            TargetFile targetFile;
            switch (inputFileBase.FileFormat)
            {
                case EnumFileFormat.Custom:
                {
                    targetFile = CreateTargetFromCustomFormat(inputFileBase);
                    break;
                }

                case EnumFileFormat.Standard:
                {
                    targetFile = CreateTargetFromStandardFormat(inputFileBase);
                    break;
                }

                default: throw new ArgumentException("File format is not correct");
            }

            return targetFile;
        }

        private TargetFile CreateTargetFromCustomFormat(IInputFile inputFile)
        {
            TargetFile targetFile;
            var customFormat = (CustomFormat) inputFile;
            var accountType = GetAccountType(customFormat.Type, EnumFileFormat.Custom);
            var currencyCode = GetCurrency(customFormat.Currency);
            targetFile = new TargetFile(customFormat.CustodianCode, customFormat.Name,
                accountType.ToString(), currencyCode.ToString());
            return targetFile;
        }

        private TargetFile CreateTargetFromStandardFormat(IInputFile inputFile)
        {
            var standardFormat = (StandardFormat) inputFile;
            var accountType = GetAccountType(standardFormat.Type.ToString(), EnumFileFormat.Custom);
            var currencyCode = GetCurrency(standardFormat.Currency);
            string identifier = standardFormat.Identifier.Substring(
                standardFormat.Identifier.IndexOf("|", StringComparison.Ordinal)+1);
            var openDateTime = standardFormat.Opened;
            var targetFile = openDateTime == null
                ? new TargetFile(identifier, standardFormat.Name,
                    accountType.ToString(), currencyCode.ToString())
                : new TargetFile(identifier, standardFormat.Name,
                    accountType.ToString(), standardFormat.Opened, currencyCode.ToString());

            return targetFile;
        }

        private EnumAccountType GetAccountType(string type, EnumFileFormat enumFileFormat)
        {
            EnumAccountType result;
            switch (enumFileFormat)
            {
                case EnumFileFormat.Standard:
                    result = (EnumAccountType) int.Parse(type);
                    break;
                case EnumFileFormat.Custom:
                    Enum.TryParse(type, out result);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enumFileFormat), enumFileFormat, null);
            }

            return result;
        }

        private EnumCurrencyCode GetCurrency(string currency)
        {
            EnumCurrencyCode result;

            switch (currency.ToUpper())
            {
                case "U":
                case "US":
                {
                    result = EnumCurrencyCode.USD;
                    break;
                }

                case "C":
                case "CD":
                {
                    result = EnumCurrencyCode.CAD;
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException($"currency code {currency} is wrong");
            }

            return result;
        }
    }
}