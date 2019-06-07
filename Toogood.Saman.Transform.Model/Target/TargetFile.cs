using System;

namespace Toogood.Saman.Transform.Model.Target
{
    public class TargetFile
    {
        public TargetFile(string accountCode, string name, string type, DateTime? openDate, string currency)
        {
            AccountCode = accountCode;
            Name = name;
            Type = type;
            OpenDate = openDate;
            Currency = currency;
        }

        public TargetFile(string accountCode, string name, string type, string currency)
        {
            AccountCode = accountCode;
            Name = name;
            Type = type;
            Currency = currency;
        }

        public string AccountCode { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime? OpenDate { get; set; }

        public string Currency { get; set; }
    }
}