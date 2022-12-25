﻿using System.Reflection;
using Autofac;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.HttpOverrides;
using WebApi.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi
{
    public static class ConfigureService
    {

        public static IServiceCollection AddWebUIServices
            (
                this IServiceCollection Services,
                WebApplicationBuilder        
                    builder
            )
        {
            // AutoFact
            builder.Host.AddAutoFact();

            // Configuration File
            ConfigurationManager configuration = builder.Configuration;

            // Settings
            Services.AddSiteConfiguration(configuration);

            // Antiforgery
            Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            // ForwardedHeaders
            Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // HttpContext
            Services.AddHttpContextAccessor();

            // Caching
            Services.AddDistributedMemoryCache();


            Services.AddControllers();

            //// WebMurkupMin
            //Services.AddWebMarkUpMin();

            //// RazorPages
            //builder.Services
            //    .AddRazorPages()
            //    .AddRazorRuntimeCompilation()
            //    .AddJsonOptions(opts =>
            //    {
            //        opts.JsonSerializerOptions.PropertyNamingPolicy = null;
            //        opts.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
            //    })
            //    .AddRazorPagesOptions(opt =>
            //    {
            //        opt.Conventions.AddPageRoute("/Home/Index", "");
            //    })
            //    .AddSessionStateTempDataProvider()
            //    ;



            return Services;
        }


        public static void  ConfigureAutofact(this IHostBuilder Host,params Assembly[] assembly)
        {

            Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.ConfigureDelegate(assembly);

                builder.RegisterSeriLogToAutoFac();

            });
        }
    }
}
