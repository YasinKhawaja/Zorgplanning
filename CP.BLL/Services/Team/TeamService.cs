using AutoMapper;
using CP.BLL.Exceptions;
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
            var teams = await _unitOfWork.Teams.FindAllAsync();
            return _mapper.Map<IList<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetOneAsync(int id)
        {
            var teams = await _unitOfWork.Teams.FindByConditionAsync(x => x.Id.Equals(id));
            var team = teams.FirstOrDefault();
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<TeamDTO> CreateAsync(TeamDTO dto)
        {
            Team team = _mapper.Map<Team>(dto);
            await _unitOfWork.Teams.CreateAsync(team);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task UpdateAsync(int id, TeamDTO dto)
        {
            IList<Team> teams = await _unitOfWork.Teams.FindByConditionAsync(x => x.Id.Equals(id));
            Team teamFound = teams.FirstOrDefault();
            if (teamFound is null)
            {
                throw new TeamNotFoundException($"TEAM WITH ID {dto.Id} NOT FOUND");
            }
            Team teamToUp = _mapper.Map<Team>(dto);
            _unitOfWork.Teams.Update(teamToUp);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            IList<Team> teams = await _unitOfWork.Teams.FindByConditionAsync(x => x.Id.Equals(id));
            Team teamFound = teams.FirstOrDefault();
            if (teamFound is null)
            {
                throw new TeamNotFoundException($"TEAM WITH ID {id} NOT FOUND");
            }
            _unitOfWork.Teams.Delete(teamFound);
            await _unitOfWork.SaveAsync();
        }
    }
}
