using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.DataProtection;

namespace SocialMedia.Helper.Crypto
{
    public class CryptoHelper : ICryptoHelper
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string _secretKey = "mySecretKey";

        public CryptoHelper(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public string Encrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(_secretKey);
            return protector.Protect(input);
        }

        public string Decrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(_secretKey);
            return protector.Unprotect(input);
        }
    }
}
