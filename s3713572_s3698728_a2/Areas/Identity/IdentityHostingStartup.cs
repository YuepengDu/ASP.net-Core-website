using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using s3713572_s3698728_a2.Data;

[assembly: HostingStartup(typeof(s3713572_s3698728_a2.Areas.Identity.IdentityHostingStartup))]
namespace s3713572_s3698728_a2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<s3713572_s3698728_a2Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("s3713572_s3698728_a2ContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<s3713572_s3698728_a2Context>();
            });
        }
    }
}