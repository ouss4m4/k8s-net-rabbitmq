using System;
using System.Collections.Generic;
using System.Linq;
using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));

            }
            command.PlatformID = platformId;
            _context.Commands.Add(command);
        }

        public void CreatePlatform(Platform model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _context.Platforms.Add(model);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _context.Commands
                        .Where(c => c.PlatformID == platformId && c.Id == commandId)
                        .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _context.Commands
                .Where(c => c.PlatformID == platformId)
                .OrderBy(c => c.Platform.Name);
        }

        public bool PlatformExits(int platformId)
        {
            return _context.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}