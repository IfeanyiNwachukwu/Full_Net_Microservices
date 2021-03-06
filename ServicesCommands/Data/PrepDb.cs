using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServicesCommands.Data.Repositories;
using ServicesCommands.Models;
using ServicesCommands.SyncDataServices.Grpc;

namespace ServicesCommands.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder )
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();

                var platforms = grpcClient.ReturnAllPlatforms();

                SeedData(serviceScope.ServiceProvider.GetService<ICommandRepo>(), platforms);
            }

        }

        private static void SeedData(ICommandRepo repo, IEnumerable<Platform> platforms)
        {
            System.Console.WriteLine("--> Seeding new Platforms...");

            if(platforms != null)
            {
                foreach (var plat in platforms)
                {
                    if(!repo.ExternalPlatformExists(plat.ExternalID))
                    {
                        repo.CreatePlatform(plat);
                    }
                    repo.SaveChanges();
                }
            }

           
        }
    }
}