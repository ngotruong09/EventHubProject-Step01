using Microsoft.Extensions.DependencyInjection;
using Payment.EntityFrameworkCore;
using System;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.CmsKit.EntityFrameworkCore;

namespace EventHub.EntityFrameworkCore
{
    [DependsOn(
        typeof(EventHubDomainModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(BlobStoringDatabaseEntityFrameworkCoreModule),
        typeof(CmsKitEntityFrameworkCoreModule),
        typeof(PaymentEntityFrameworkCoreModule)
        )]
    public class EventHubEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            EventHubEfCoreEntityExtensionMappings.Configure();
            
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EventHubDbContext>(options =>
            {
                options.AddDefaultRepositories();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}
