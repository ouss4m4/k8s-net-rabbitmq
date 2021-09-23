using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repo;
        private IMapper _mapper;

        public CommandsController(ICommandRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> getting commands for platform {platformId}");

            if (!_repo.PlatformExits(platformId))
            {
                return NotFound();
            }

            var result = _repo.GetCommandsForPlatform(platformId);

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(result));
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]

        public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
        {
            Console.WriteLine($"--> GetCommandsForPlatform  pid: {platformId}, cid:{commandId}");

            if (!_repo.PlatformExits(platformId))
            {
                return NotFound();
            }

            var command = _repo.GetCommand(platformId, commandId);

            if (command == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto data)
        {
            Console.WriteLine($"--> CreateCommandForPlatform  pid: {platformId}, cid:{data.CommandLine }, {data.HowTo}");

            if (!_repo.PlatformExits(platformId))
            {
                return NotFound();
            }

            var command = _mapper.Map<Command>(data);
            _repo.CreateCommand(platformId, command);
            _repo.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(
                nameof(GetCommandForPlatform),
                new { platformId = platformId, commandId = commandReadDto.Id },
                commandReadDto
                );
        }
    }
}