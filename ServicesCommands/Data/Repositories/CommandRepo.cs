using System;
using System.Collections.Generic;
using System.Linq;
using ServicesCommands.Models;

namespace ServicesCommands.Data.Repositories
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCommand(int platformId, Command model)
        {
           if(model == null)
           {
               throw new ArgumentException(nameof(model));
           }
           model.PlatformID = platformId;
           _context.Commands.Add(model);
        }

        public void CreatePlatform(Platform model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _context.Platforms.Add(model);
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return _context.Platforms.Any(p => p.ExternalID.Equals(externalPlatformId));
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _context.Commands.Where(c => c.PlatformID.Equals(platformId) && c.Id.Equals(commandId))
            .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _context.Commands.Where(c => c.PlatformID.Equals(platformId))
            .OrderBy(c => c.Platform.Name);
        }

        public bool PlatformExists(int platformId)
        {
            return _context.Platforms.Any(p => p.Id.Equals(platformId));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}