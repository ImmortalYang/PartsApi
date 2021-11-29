
namespace PartsDomain
{
    public class PartAggregate
    {
        public PartNumber PartNumber { get; private set; }
        public string Description { get; private set; }

        public PartAggregate(PartNumber partNumber, string description)
        {
            PartNumber = partNumber;
            Description = description;
        }
    }
}
