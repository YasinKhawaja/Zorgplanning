﻿using Ardalis.GuardClauses;
using AutoMapper;
using CP.BLL.DTOs;
using CP.BLL.Extensions;
using CP.DAL.Models;
using CP.DAL.UnitOfWork;

namespace CP.BLL.Services
{
    /// <summary>
    /// Implements <seealso cref="ITeamService"/>.
    /// </summary>
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<TeamDTO>> GetAllAsync()
        {
            var teams = await _unitOfWork.Teams.FindAllAsync(
                nameof(Team.Employees),
                x => x.OrderBy(x => x.Name));
            return _mapper.Map<IList<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetAsync(int id)
        {
            var teams = await _unitOfWork.Teams
                .FindByAsync(x => x.Id == id, include: nameof(Team.Employees));
            var team = teams.FirstOrDefault();
            Guard.Against.IsTeamFound(team);
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<TeamDTO> CreateAsync(TeamDTO dto)
        {
            Team team = _mapper.Map<Team>(dto);
            await _unitOfWork.Teams.AddAsync(team);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task UpdateAsync(int id, TeamDTO dto)
        {
            IList<Team> teams = await _unitOfWork.Teams.FindByAsync(x => x.Id == id);
            Team teamToUp = teams.FirstOrDefault();
            Guard.Against.IsTeamFound(teamToUp);
            teamToUp.Name = dto.Name;
            _unitOfWork.Teams.Update(teamToUp);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            IList<Team> teams = await _unitOfWork.Teams.FindByAsync(x => x.Id == id, include: nameof(Team.Employees));
            Team teamFound = teams.FirstOrDefault();
            Guard.Against.IsTeamFound(teamFound);
            Guard.Against.HasTeamEmployees(teamFound);
            _unitOfWork.Teams.Remove(teamFound);
            await _unitOfWork.SaveAsync();
        }
    }
}
