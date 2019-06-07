namespace Toogood.Saman.Transform.Model.Input
{
    public class CustomFormat : InputFileBase<string>
    {
        public CustomFormat(string name, string type, string currency, string custodianCode) :
            base(name, type, currency)
        {
            CustodianCode = custodianCode;
        }

        public string CustodianCode { get; private set; }

        public override EnumFileFormat FileFormat => EnumFileFormat.Custom;
    }
}