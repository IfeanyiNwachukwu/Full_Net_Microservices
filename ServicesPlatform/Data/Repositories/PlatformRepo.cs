using System;
using System.Collections.Generic;
using System.Linq;
using ServicesPlatform.Contracts.RepoContracts;
using ServicesPlatform.Models;

namespace ServicesPlatform.Data.Repositories
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;
        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms() => _context.Platforms.ToList();

        public Platform GetPlatformById(int id) => _context.Platforms.FirstOrDefault(p => p.Id.Equals(id));

        public bool SaveChanges() => (_context.SaveChanges() >= 0);
    }
}