using Ensek.Test.Domain.Common;
using System;

namespace Ensek.Test.Domain.Entities
{
    public class MeterReading : BaseEntity
    {
        public DateTime ReadingDateTime { get; set; }
        public int Value { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
