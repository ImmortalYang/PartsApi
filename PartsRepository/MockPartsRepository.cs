using Newtonsoft.Json;
using PartsApplication.Storages;
using PartsDomain;
using System.Collections.Generic;
using System.Linq;

namespace PartsRepository
{
    public class MockPartsRepository : IPartsRepository
    {
        public PartAggregate GetPart(PartNumber partNumber)
        {
            return new PartAggregate(partNumber, "A mocked part");
        }

        public IList<PartNumber> GetExclusions()
        {
            var texts = System.IO.File.ReadAllText("Exclusions.json");
            var parts = JsonConvert.DeserializeAnonymousType(texts, new []{ new { PartNumber = "", Description = "" } });
            return parts.Select(p => PartNumber.Parse(p.PartNumber)).ToList();
        }
    }
}
