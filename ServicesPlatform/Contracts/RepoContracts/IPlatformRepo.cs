using System.Collections.Generic;
using ServicesPlatform.Models;

namespace ServicesPlatform.Contracts.RepoContracts
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform plat);
    }
}