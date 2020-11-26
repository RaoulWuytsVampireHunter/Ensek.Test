using CsvHelper;
using Ensek.Test.Application.Interfaces;
using Ensek.Test.Application.Utils.Csv.Mapping;
using Ensek.Test.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ensek.Test.Application.Utils.Csv
{
    public class CsvImporter : ICsvImporter
    {
        private const string _delimiter = ",";

        public async Task<List<MeterReadingImportDto>> ReadCsvAsync(IFormFileCollection files, CancellationToken ct = default)
        {
            List<MeterReadingImportDto> list = new List<MeterReadingImportDto>();
            foreach (var file in files)
            {
                using (var rdr = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(rdr, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<MeterReadingImportMapping>();
                    csv.Configuration.Delimiter = _delimiter;

                    list = csv.GetRecords<MeterReadingImportDto>().ToList();
                }
            }
            return list;
        }
    }
}
