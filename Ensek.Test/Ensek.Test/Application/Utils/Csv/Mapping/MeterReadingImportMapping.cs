using CsvHelper.Configuration;
using Ensek.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensek.Test.Application.Utils.Csv.Mapping
{
    public class MeterReadingImportMapping : ClassMap<MeterReadingImportDto>
    {
        public MeterReadingImportMapping()
        {
            Map(x => x.AccountId).Name("AccountId");
            Map(x => x.MeterReadingDateTime).Name("MeterReadingDateTime");
            Map(x => x.MeterReadValue).Name("MeterReadValue");
        }
    }
}
