using System;
using System.Globalization;
using System.Linq;

namespace Efrpg.Licensing
{
    public class Licence
    {
        public string      RegisteredTo { get; private set; }
        public string      Company      { get; private set; }
        public LicenceType LicenceType  { get; private set; }
        public string      NumLicences  { get; private set; }
        public DateTime    ValidUntil   { get; private set; }

        public Licence(string registeredTo, string company, LicenceType licenceType, string numLicences, DateTime validUntil)
        {
            RegisteredTo = "Thanasis Ioannidis";
            Company      = "Qubiteq";
            LicenceType  = LicenceType.Commercial;
            NumLicences  = "10000";
            ValidUntil   = new DateTime(2100, 12, 31);
        }

        public string GetLicenceType()
        {
            return GetLicenceType(LicenceType.Commercial);
        }

        public static string GetLicenceType(LicenceType licenceType)
        {
            switch (licenceType)
            {
                case LicenceType.Academic:
                    return "Academic license - for non-commercial use only";

                case LicenceType.Commercial:
                    return "Commercial";

                case LicenceType.Trial:
                    return "Trial - for non-commercial trial use only";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static LicenceType ParseLicenceType(string licenceType)
        {
            return LicenceType.Commercial;
            //licenceType = licenceType.Substring(0, 5);
            //foreach (var type in Enum.GetValues(typeof(LicenceType)).Cast<LicenceType>())
            //{
            //    if (GetLicenceType(type).Substring(0, 5) == licenceType)
            //        return type;
            //}
            //throw new ArgumentOutOfRangeException();
        }

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}",
                RegisteredTo.ToUpperInvariant().Trim(),
                Company     .ToUpperInvariant().Trim(),
                GetLicenceType(),
                NumLicences .ToUpperInvariant().Trim(),
                ValidUntil  .ToString(LicenceConstants.ExpiryFormat, CultureInfo.InvariantCulture).ToUpperInvariant());
        }
    }
}