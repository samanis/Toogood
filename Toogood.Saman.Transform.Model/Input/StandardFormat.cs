using System;

namespace Toogood.Saman.Transform.Model.Input
{
    public class StandardFormat : InputFileBase<int>
    {
        public StandardFormat(string name, int type, string currency, string identifier, DateTime? opened) : 
            base(name, type, currency)
        {
            Identifier = identifier;
            Opened = opened;
        }

        public string Identifier { get; private set; }
        public DateTime? Opened { get; private set; }
        
        public override EnumFileFormat FileFormat => EnumFileFormat.Standard;
    }
}
