using Microsoft.EntityFrameworkCore;
using OS.ComputerComponentsBuilder.Infrastructure;

namespace OS.ComputerComponentsBuilder.Seed
{
    public static class SeedHelper
    {
        public async static Task SeedAsync(this IServiceProvider serviceProvider)
        {
            await using (var scope = serviceProvider.CreateAsyncScope())
            {
                var store = scope.ServiceProvider.GetRequiredService<ApplicationStorage>();

                if (store.Database.IsNpgsql())
                {
                    await store.Database.MigrateAsync();
                }

                await serviceProvider.InitializeDatabaseAsync(store);
            }
        }
    }
}
