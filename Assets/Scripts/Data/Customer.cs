using System;
using FileHelpers;

namespace Data
{
    [DelimitedRecord(",")]
    public class Customer
    {
        public int CustId;

        public string Name;

        public decimal Balance;

        [FieldConverter(ConverterKind.Date, "dd-MM-yyyy")] public DateTime AddedDate;

        public override string ToString() {
            return $"{nameof(CustId)}: {CustId}, {nameof(Name)}: {Name}, {nameof(Balance)}: {Balance}, {nameof(AddedDate)}: {AddedDate}";
        }
    }
}