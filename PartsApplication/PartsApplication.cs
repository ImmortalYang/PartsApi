using PartsApplication.Storages;
using PartsDomain;
using System;
using System.Linq;

namespace PartsApplication
{
    public class PartsApplication : IPartsApplication
    {
        private readonly IPartsRepository _partsRepository;

        public PartsApplication(IPartsRepository partsRepository)
        {
            _partsRepository = partsRepository;
        }

        public PartAggregate GetPart(string partNumberStr)
        {
            var partNumber = PartNumber.Parse(partNumberStr);

            var exclusions = _partsRepository.GetExclusions();
            if (exclusions.Any(excludePartNumber => partNumber.Equals(excludePartNumber)))
            {
                return null;
            }

            return _partsRepository.GetPart(partNumber);
        }
    }
}
