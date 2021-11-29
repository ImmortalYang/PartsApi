using PartsDomain;

namespace PartsApplication
{
    public interface IPartsApplication
    {
        PartAggregate GetPart(string partNumber);
    }
}
