using PartsDomain;
using System.Collections.Generic;

namespace PartsApplication.Storages
{
    public interface IPartsRepository
    {
        PartAggregate GetPart(PartNumber partNumber);
        IList<PartNumber> GetExclusions();
    }
}
