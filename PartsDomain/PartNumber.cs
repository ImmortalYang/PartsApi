using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace PartsDomain
{
    public class PartNumber : IEquatable<PartNumber>
    {
        public string PartId { get; private set; }
        public string PartCode { get; private set; }

        public PartNumber(string partId, string partCode)
        {
            if (string.IsNullOrEmpty(partId))
            {
                throw new ArgumentException(nameof(partId));
            }
            if (string.IsNullOrEmpty(partCode))
            {
                throw new ArgumentException(nameof(partCode));
            }
            if (!Regex.IsMatch(partId, "^([0-9]){4}$"))
            {
                throw new ArgumentException(nameof(partId));
            }
            if (!Regex.IsMatch(partCode, "^([a-zA-Z0-9]){4,}$"))
            {
                throw new ArgumentException(nameof(partCode));
            }

            PartId = partId;
            PartCode = partCode;
        }

        public override string ToString()
        {
            return PartId + "-" + PartCode;
        }

        public static PartNumber Parse(string partStr)
        {
            if (string.IsNullOrEmpty(partStr))
            {
                throw new ArgumentNullException(nameof(partStr));
            }

            var segments = partStr.Split('-');
            if (segments.Length != 2)
            {
                throw new ArgumentException(nameof(partStr));
            }

            return new PartNumber(partId: segments[0], partCode: segments[1]);
        }

        public static bool TryParse(string partStr, out PartNumber partNumber)
        {
            try
            {
                partNumber = Parse(partStr);
                return true;
            }
            catch (Exception)
            {
                partNumber = null;
                return false;
            }
        }

        public bool Equals([AllowNull] PartNumber other)
        {
            if (other == null)
            {
                return false;
            }

            return this.ToString().Equals(other.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
