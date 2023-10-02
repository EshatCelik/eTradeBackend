using eTradeBackend.Application.Abstract.Storage;
using eTradeBackend.Application.Abstract.Token;
using eTradeBackend.Application.Services;
using eTradeBackend.Application.Services.Configuration;
using eTradeBackend.Infrastructure.Enum;
using eTradeBackend.Infrastructure.Services.Configurations;
using eTradeBackend.Infrastructure.Services.Mail;
using eTradeBackend.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Infrastructure
{
    public static class AllServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            //services.AddScoped<IQRCodeService, QRCodeService>();
        }
        //public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        //{
        //    services.AddScoped<IStorage, T>();
        //}
        //public static void AddStorage(this IServiceCollection services, StorageType storageType)
        //{
        //    switch (storageType)
        //    {
        //        case StorageType.Local:
        //            services.AddScoped<IStorage, LocalStorage>();
        //            break;
        //        case StorageType.Azure:
        //            services.AddScoped<IStorage, AzureStorage>();
        //            break;
        //        case StorageType.AWS:
        //            break;
        //        default:
        //            services.AddScoped<IStorage, LocalStorage>();
        //            break;
        //    }
        
    }
}
