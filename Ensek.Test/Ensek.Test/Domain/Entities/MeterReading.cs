using Ensek.Test.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ensek.Test.Domain.Entities
{
    public class MeterReading : BaseEntity
    {
        public DateTime ReadingDateTime { get; set; }
        public string Value { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
