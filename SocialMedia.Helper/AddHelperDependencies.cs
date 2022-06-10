using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Helper.Crypto;
using SocialMedia.Helper.File;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Helper.DependencyInjection
{
    public class AddHelperDependencies
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFileHelper, FileHelper>();
            services.AddTransient<ICryptoHelper, CryptoHelper>();
        }
    }
}
