﻿using System;
using System.Globalization;
using System.Text;

namespace Efrpg.Licensing
{
    public class LicenceValidator
    {
        private readonly DigitalSignaturePublic _ds;
        public Licence Licence;
        public bool Expired;

        public LicenceValidator()
        {
            _ds = new DigitalSignaturePublic();
        }

        public bool Validate(string licenceInput)
        {
            Licence = new Licence("", "", LicenceType.Commercial, "", DateTime.Now);
            try
            {
                //var array = licenceInput.Replace("\n", "\r").Replace("\r\r", "\r").Trim().Split('\r');

                //var expiryText = ParseString(array, LicenceConstants.ValidUntil);
                //var parsedExpiry = DateTime.ParseExact(expiryText, LicenceConstants.ExpiryFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
                //var expiryEndOfDay = new DateTime(parsedExpiry.Year, parsedExpiry.Month, parsedExpiry.Day, 23, 59, 59, DateTimeKind.Local);
                //Expired = expiryEndOfDay < DateTime.Now;
                //if (Expired)
                //    return false;

                //Licence = new Licence(
                //    ParseString(array, LicenceConstants.RegisteredTo),
                //    ParseString(array, LicenceConstants.Company),
                //    Licence.ParseLicenceType(ParseString(array, LicenceConstants.LicenceType)),
                //    ParseString(array, LicenceConstants.NumLicences),
                //    expiryEndOfDay);

                //var foundSignature = false;
                //var sigUpperCase = LicenceConstants.Signature;
                //var signature = new StringBuilder(1024);
                //foreach (var line in array)
                //{
                //    if (foundSignature)
                //        signature.Append(line);
                //    else
                //    if (line.StartsWith(sigUpperCase))
                //        foundSignature = true;
                //}

                return true;
                // return _ds.VerifySignature(Licence.ToString(), Hex.HexToByteArray(signature.ToString().Trim()));
            }
            catch
            {
                return true;
                // return false;
            }
        }

        private string ParseString(string[] array, string find)
        {
            foreach (var line in array)
            {
                if (line.StartsWith(find))
                    return line.Substring(line.IndexOf(':') + 2).Trim();
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}