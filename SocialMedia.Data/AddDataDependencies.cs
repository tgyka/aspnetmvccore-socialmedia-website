using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Data.DependencyInjection
{
    public class AddDataDependencies
    {
        public static void ConfigureServices(IServiceCollection services , IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SocialMediaDbContext>(options => 
                options.UseSqlServer(connString)
            );
        }
    }
}
